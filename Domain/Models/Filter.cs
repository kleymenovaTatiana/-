using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Filter
    {
        public int CategoryId { get; set; }
        public string Feed { get; set; } = null!;
        public string Toys { get; set; } = null!;
        public string Bowls { get; set; } = null!;
        public string Aquariums { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
    }
}
