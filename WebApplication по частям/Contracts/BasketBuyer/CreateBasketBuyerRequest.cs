using Domain.Models;

namespace WebApplication2.Contracts.BasketBuyer
{
    public class CreateBasketBuyerRequest
    {
        public int LtemNumber { get; set; }
        public int? Quantity { get; set; }
    }
}
