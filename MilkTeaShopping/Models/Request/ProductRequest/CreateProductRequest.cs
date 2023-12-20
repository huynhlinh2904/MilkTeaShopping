namespace MilkTeaShopping.Models.Request.ProductRequest
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; } = null!;

        public int Price { get; set; }

        public string Image { get; set; } = null!;

        public bool Status { get; set; }
        public Guid CategoryId { get; set; }
    }
}
