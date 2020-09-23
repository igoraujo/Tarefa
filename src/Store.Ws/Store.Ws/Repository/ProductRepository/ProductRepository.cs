using Store.Data.Models;
using Store.Data.Repository.Base;

namespace StoreWS.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly StoreContext _absCardContext;

        public ProductRepository(StoreContext context) : base(context)
        {
            _absCardContext = context;
        }
    }
}