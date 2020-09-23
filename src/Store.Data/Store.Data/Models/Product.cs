using System;
using System.Collections.Generic;

namespace Store.Data.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
