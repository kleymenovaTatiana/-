﻿using Domain.Models;

namespace WebApplication2.Contracts.BasketBuyer
{
    public class GetBasketBuyerResponse
    {
        public int IdUser { get; set; }
        public int LtemNumber { get; set; }
        public int? Quantity { get; set; }
    }
}
