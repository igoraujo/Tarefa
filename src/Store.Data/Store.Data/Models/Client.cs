using Store.Data.Enum;
using System;
using System.Collections.Generic;

namespace Store.Data.Models
{
    public class Client
    {
        public Client()
        {
            Orders = new List<Order>();
        }

        public Guid ClientId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
