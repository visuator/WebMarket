using Microsoft.AspNetCore.Mvc;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {

        [HttpGet()]
        public async Task<IActionResult> GetCart([FromQuery] GetCartProductsModel model, CancellationToken token = default)
        {
            return Ok();
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToCart([FromRoute] Guid productId, CancellationToken token = default)
        {
            return Ok();
        }
    }
}
