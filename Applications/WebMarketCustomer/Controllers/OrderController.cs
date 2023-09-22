using Microsoft.AspNetCore.Mvc;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> GetOrder()
        {
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> CancelOrder()
        {
            return Ok();
        }
    }
}
