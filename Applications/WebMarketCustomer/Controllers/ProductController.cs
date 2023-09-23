using Microsoft.AspNetCore.Mvc;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> FindProducts([FromQuery] FindProductsModel model, CancellationToken token = default)
        {
            return Ok();
        }
    }
}
