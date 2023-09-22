using Microsoft.AspNetCore.Mvc;

namespace WebMarketDelivery.Controllers
{
    [ApiController]
    [Route("api/delivery")]
    public class DeliveryController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> Deliver()
        {
            return Ok();
        }
    }
}
