using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using MilkTeaShopping.Core.CoreModel;
using MilkTeaShopping.Entities;
using MilkTeaShopping.Models.Request.ProductRequest;
using MilkTeaShopping.Models.Response.ProductResponse;

namespace MilkTeaShopping.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly MilkTeaShoppingContext dbContext;
        private readonly IMapper _map;

        public ProductService(MilkTeaShoppingContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this._map = mapper;
        }

        public async Task<APIResponse<GetProductResponse>> CreateProduct(CreateProductRequest request)
        {
            APIResponse<GetProductResponse> Response = new();
            var product = await dbContext.Products.SingleOrDefaultAsync(x => x.ProductName.ToUpper().Equals(request.ProductName.ToUpper()));
            if (product != null)
            {
                Response.ToFailedResponse("sản phẩm đã tồn tại", StatusCodes.Status400BadRequest);
                return Response;
            }
            var id = new Guid();
            Product createProduct = new Product();
            {
                createProduct.ProductId = id;
                createProduct.ProductName = request.ProductName;
                createProduct.Status = true;
                createProduct.Price = request.Price;
                createProduct.CategoryId = request.CategoryId;
            }
            await dbContext.Products.AddAsync(createProduct);
            await dbContext.SaveChangesAsync();
            var map = _map.Map<GetProductResponse>(createProduct);
            Response.ToSuccessResponse("Tạo thành công", StatusCodes.Status200OK);
            Response.Data = map;
            return Response;

        }

        public async Task<APIResponse<IEnumerable<GetProductResponse>>> GetAllProduct()
        {
            APIResponse<IEnumerable<GetProductResponse>> Response = new();
            var product = await dbContext.Products.ToListAsync();
            if (product == null)
            {
                Response.ToFailedResponse("Không tìm thấy danh sách", StatusCodes.Status404NotFound);
                return Response;
            }
            IEnumerable<GetProductResponse> result = product.Select(
                x =>
                {
                    return new GetProductResponse()
                    {
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        Price = x.Price,
                        Image = x.Image,
                        CategoryId = x.CategoryId,
                        Status = x.Status,
                    };
                }
                ).ToList();
            Response.Data = result;
            Response.ToSuccessResponse(Response.Data, "lấy danh sách thành công", StatusCodes.Status200OK);
            return Response;
        }

        public async Task<APIResponse<UpdateProductResponse>> Update(UpdateRequest updateRequest)
        {
            APIResponse<UpdateProductResponse> response = new();
            var productId = await dbContext.Products.FirstOrDefaultAsync();
            if (productId == null)
            {
                response.ToFailedResponse("Không tìm thấy sản phẩm", StatusCodes.Status404NotFound);
                return response;
            }
            Product product = new Product();
            product.Price = updateRequest.Price;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            var map = _map.Map<GetProductResponse>(updateRequest);
            response.ToSuccessResponse("Tạo thành công", StatusCodes.Status200OK);
            response.Data = map;
            return response;
        }
    }
}
