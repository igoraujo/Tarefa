using Store.Data.Models;
using System;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public interface IProductService
    {
        List<Product> Get();

        Product Get(Guid id);
    }
}
