using System;
using System.Collections.Generic;

namespace Domain.Models 
{
    public partial class Category
    {
        public Category()
        {
            Products1s = new HashSet<Products1>();
        }

        public int CategoryId { get; set; }
        public string ForDogs { get; set; } = null!;
        public string ForCats { get; set; } = null!;
        public string Aquariums { get; set; } = null!;
        public string ForBirds { get; set; } = null!;

        public virtual Filter? Filter { get; set; }
        public virtual ICollection<Products1> Products1s { get; set; }
    }
}
