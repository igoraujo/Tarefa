using Store.Data.Models;
using StoreWS.UnitOfWork;
using System;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Product> Get()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = new Guid("74770E08-382F-4984-9297-014521A327F4"),
                    Name = "Teclado Multimídia KR85"
                },
                new Product
                {
                    ProductId = new Guid("4274361B-1DBA-4F5A-A1BA-0234D268C2F5"),
                    Name = "Mouse Óptico MO179"
                },
                new Product
                {
                    ProductId = new Guid("F9AC77F5-1495-45EE-87BD-033F948445BA"),
                    Name = "Teclado FF342"
                },
                new Product
                {
                    ProductId = new Guid("8F89AB13-3C99-495A-8CA0-04A536B1A298"),
                    Name = "Monitor Led 15 HG67"
                },
                new Product
                {
                    ProductId = new Guid("5E16F8AB-2E8E-49D0-BE97-07553D93A262"),
                    Name = "Monitor 25 JJR12"
                },
                new Product
                {
                    ProductId = new Guid("59662710-0E4C-46B9-8BFD-0A389BAB62F5"),
                    Name = "Mouse CWT98"
                }
            };

            return products;
        }
    }
}