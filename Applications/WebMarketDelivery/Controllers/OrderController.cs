using Microsoft.AspNetCore.Mvc;

namespace WebMarketDelivery.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> BuildOrder()
        {
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> ReturnOrder()
        {
            return Ok();
        }
    }
}
