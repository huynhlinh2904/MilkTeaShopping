using AutoMapper;

namespace MilkTeaShopping.Helper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Entities.Product, Models.Response.ProductResponse.GetProductResponse>().ReverseMap();
        }
    }
}
