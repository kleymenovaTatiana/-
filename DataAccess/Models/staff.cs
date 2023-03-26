using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class staff
    {
        public staff()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeCode { get; set; }
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Namee { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
