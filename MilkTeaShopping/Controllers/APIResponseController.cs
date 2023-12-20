using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkTeaShopping.Core.CoreModel;

namespace MilkTeaShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIResponseController : ControllerBase
    {
        protected IActionResult SendResponse<T>(T response) where T : ApiResponse
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        protected IActionResult SendResponse<T>(APIResponse<T> response) where T : class
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        protected IActionResult SendResponse(ApiResponseListError response)
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
