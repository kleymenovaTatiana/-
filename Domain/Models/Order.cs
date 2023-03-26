using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Order
    {
        public int OrderCode { get; set; }
        public int IdUser { get; set; }
        public int LtemNumber { get; set; }
        public int EmployeeCode { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Status { get; set; } = null!;
        public int? Quantity { get; set; }
        public string DeliveryMethod { get; set; } = null!;

        public virtual staff EmployeeCodeNavigation { get; set; } = null!;
        public virtual Customer IdUserNavigation { get; set; } = null!;
        public virtual Products1 LtemNumberNavigation { get; set; } = null!;
    }
}
