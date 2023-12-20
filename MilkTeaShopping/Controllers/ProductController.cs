using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkTeaShopping.Models.Request.ProductRequest;
using MilkTeaShopping.Service.ProductService;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkTeaShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : APIResponseController
    {
        private readonly IProductService _Product;

        public ProductController(IProductService product)
        {
            this._Product = product;
        }
        [HttpGet]
        [SwaggerOperation(summary: "Get All Product")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var result = await _Product.GetAllProduct();
                if (result == null)
                {
                    return BadRequest(result?.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [SwaggerOperation(summary:"Create product")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            try
            {
                var result = await _Product.CreateProduct(request);
                if (result == null)
                {
                    return BadRequest(result?.Message);
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [SwaggerOperation(summary: "Update Product")]
        public async Task<IActionResult> UpdateProduct(CreateProductRequest request)
        {
            try
            {
                var result = await _Product.Update(request);
                if (result == null)
                {
                    return BadRequest(result?.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
