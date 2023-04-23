namespace WebApplication2.Contracts.Order
{
    public class GetOrderResponse
    {
        public int OrderCode { get; set; }
        public int IdUser { get; set; }
        public int LtemNumber { get; set; }
        public int EmployeeCode { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Status { get; set; } = null!;
        public int? Quantity { get; set; }
        public string DeliveryMethod { get; set; } = null!;
    }
}
