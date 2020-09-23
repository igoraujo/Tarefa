using Store.Data.Models;
using StoreWS.UnitOfWork;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateOrder(List<Order> orders)
        {
            _unitOfWork.OrderRepository.AddAll(orders);
        }
    }
}