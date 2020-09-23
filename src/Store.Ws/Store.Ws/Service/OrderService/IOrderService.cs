using Store.Data.Models;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public interface IOrderService
    {
        void CreateOrder(List<Order> orders);
    }
}
