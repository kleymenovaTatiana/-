using System;
using System.Collections.Generic;


namespace Domain.Models
{
    public partial class Products1
    {
        public Products1()
        {
            BasketBuyers = new HashSet<BasketBuyer>();
            Orders = new HashSet<Order>();
        }

        public int LtemNumber { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public decimal Cost { get; set; }
        public string Description { get; set; } = null!;
        public int ArticleNumber { get; set; }
        public int NumberInClade { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<BasketBuyer> BasketBuyers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
