using Domain.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Products1s = new HashSet<Products1>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual Filter Filter { get; set; }
        public virtual ICollection<Products1> Products1s { get; set; }
    }
}
