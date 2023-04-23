namespace WebApplication2.Contracts.Filter
{
    public class GetFilterResponse
    {
        public int CategoryId { get; set; }
        public string Feed { get; set; } = null!;
        public string Toys { get; set; } = null!;
        public string Bowls { get; set; } = null!;
        public string Aquariums { get; set; } = null!;
    }
}
