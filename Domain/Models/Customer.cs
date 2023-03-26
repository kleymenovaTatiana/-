using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BasketBuyers = new HashSet<BasketBuyer>();
            Orders = new HashSet<Order>();
        }

        public int ClieNtCode { get; set; }
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Birthdate { get; set; }

        public virtual ICollection<BasketBuyer> BasketBuyers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
