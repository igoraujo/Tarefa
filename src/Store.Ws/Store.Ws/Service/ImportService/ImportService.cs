using Store.Data.Models;
using StoreWS.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StoreWS.Service
{
    public class ImportService : IImportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ImportFile(string filePath)
        {
            var fileItems = ReadFile(filePath);

            var clients = ExtractClients(fileItems);

            var itemDistincts = ItemDistincts(fileItems);

            var orders = BuildOrdes(clients, itemDistincts);

            _unitOfWork.OrderRepository.AddAll(orders);
        }
        private static List<Item> ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception(message: "Arquvo a ser extraido não encontrado");
            }

            string[] lines = File.ReadAllLines(filePath);

            var itens = new List<Item>();

            //monta a lista de pedidos (orders) extraidos do txt
            foreach (string line in lines.Skip(1))
            {
                if (line.Length > 0)
                {
                    string[] orderLine = line.Split(';');

                    var clientId = Guid.Parse(orderLine[0]);
                    var productId = Guid.Parse(orderLine[1]);
                    int quantity = Convert.ToInt32(orderLine[2].Trim());

                    var clientProductHashValue = $"{clientId}{productId}";

                    var item = new Item
                    {
                        ClientId = clientId,
                        ProductId = productId,
                        Quantity = quantity,
                        ClientProductHashValue = clientProductHashValue
                    };
                    itens.Add(item);
                }
            }

            return itens;
        }

        private List<Client> ExtractClients(List<Item> fileItems)
        {
            var clientsId = fileItems.Select(x => x.ClientId).Distinct().ToList();

            var clients = new List<Client>();

            foreach (var item in clientsId)
            {
                var client = new ClientService(_unitOfWork).Get(item);
                clients.Add(client);
            }

            return clients;
        }

        private static List<Item> ItemDistincts(List<Item> items)
        {
            var itemDistinctHashValues = items.Select(x => x.ClientProductHashValue).Distinct().ToList();

            var itemDistincts = new List<Item>();

            foreach (var itemDistinctHashValue in itemDistinctHashValues)
            {
                var newItem = items.Where(x => x.ClientProductHashValue == itemDistinctHashValue).FirstOrDefault();

                newItem.Quantity = items.Where(x => x.ProductId == newItem.ProductId &&
                                                    x.ClientId == newItem.ClientId)
                                        .Sum(x => x.Quantity);

                itemDistincts.Add(newItem);
            }

            return itemDistincts;
        }

        private List<Order> BuildOrdes(List<Client> clients, List<Item> itemDistincts)
        {
            int number = 0;

            var orders = new List<Order>();

            foreach (var client in clients)
            {
                number++;

                var orderId = Guid.NewGuid();

                var orderItem = BuildOrderItem(itemDistincts, client, orderId);

                var newOrder = new Order
                {
                    OrderId = orderId,
                    Number = number,
                    ClientId = client.ClientId,
                    CreatedOn = DateTime.Now,
                    OrderItem = orderItem
                };

                orders.Add(newOrder);

                var localOrders = new List<Order> { newOrder };

                newOrder.Client = client;

                client.Orders = localOrders;
            }

            return orders;
        }

        private OrderItem BuildOrderItem(List<Item> itemDistincts, Client client, Guid orderId)
        {
            var orderItem = new OrderItem();

            foreach (var itemDistinct in itemDistincts)
            {
                if (itemDistinct.ClientId == client.ClientId)
                {
                    var newItensDistincts = itemDistincts.Where(x => x.ClientId == itemDistinct.ClientId).ToList();

                    var products = ExtractProducts(newItensDistincts);

                    orderItem.OrderItemId = Guid.NewGuid();
                    orderItem.OrderId = orderId;
                    orderItem.ProductId = itemDistinct.ProductId;
                    orderItem.Quantity = itemDistinct.Quantity;
                    orderItem.Products = products;
                }
            }

            return orderItem;
        }

        private List<Product> ExtractProducts(List<Item> newItensDistincts)
        {
            var products = new List<Product>();

            foreach (var item in newItensDistincts)
            {
                var product = new ProductService(_unitOfWork).Get(item.ProductId);

                products.Add(product);
            }

            return products;
        }
    }

    public class Item
    {
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual string ClientProductHashValue { get; set; }
    }
}