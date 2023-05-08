using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class BasketBuyer
    {
        public int IdUser { get; set; }
        public int LtemNumber { get; set; }
        public int? Quantity { get; set; }

        public virtual Customer IdUserNavigation { get; set; } = null!;
        public virtual Products1 LtemNumberNavigation { get; set; } = null!;
    }
}
