using Microsoft.AspNetCore.Mvc;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> FindProducts()
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> AddToCart()
        {
            return Ok();
        }
    }
}
