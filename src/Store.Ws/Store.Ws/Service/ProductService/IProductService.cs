using Store.Data.Models;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public interface IProductService
    {
        List<Product> Get();
    }
}
