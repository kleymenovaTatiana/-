namespace WebApplication2.Contracts.Filter
{
    public class CreateFilterRequest
    {
        public string Feed { get; set; } = null!;
        public string Toys { get; set; } = null!;
        public string Bowls { get; set; } = null!;
        public string Aquariums { get; set; } = null!;
    }
}
