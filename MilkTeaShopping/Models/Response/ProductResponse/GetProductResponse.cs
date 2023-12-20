namespace MilkTeaShopping.Models.Response.ProductResponse
{
    public class GetProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public int Price { get; set; }

        public string Image { get; set; } = null!;

        public bool Status { get; set; }

        public Guid CategoryId { get; set; }
    }
}
