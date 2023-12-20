using MilkTeaShopping.Core.CoreModel;
using MilkTeaShopping.Models.Request.ProductRequest;
using MilkTeaShopping.Models.Response.ProductResponse;

namespace MilkTeaShopping.Service.ProductService
{
    public interface IProductService
    {
        public Task<APIResponse<IEnumerable<GetProductResponse>>> GetAllProduct();
        public Task<APIResponse<GetProductResponse>> CreateProduct(CreateProductRequest request);

        public Task<APIResponse<UpdateProductResponse>> Update(UpdateRequest updateRequest);
    }
}
