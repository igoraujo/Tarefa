using Store.Data.Models;
using Store.Data.Repository.Base;

namespace StoreWS.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(StoreContext context) : base(context)
        {

        }
    }
}