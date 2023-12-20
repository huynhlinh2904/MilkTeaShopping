namespace MilkTeaShopping.Models.Response.ProductResponse
{
    public class UpdateProductResponse
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Price { get; set; }

        public static implicit operator UpdateProductResponse(GetProductResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
