using System;
using System.Collections.Generic;

namespace Store.Data.Models
{
    public class Order
    {
        public Order()
        {
        }

        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public Guid ClientId { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Value { get; set; }
        public virtual Client Client { get; set; }
    }
}
