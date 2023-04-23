namespace WebApplication2.Contracts.Products1
{
    public class GetProducts1Response
    {
        public int LtemNumber { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public decimal Cost { get; set; }
        public string Description { get; set; } = null!;
        public int ArticleNumber { get; set; }
        public int NumberInClade { get; set; }
    }
}
