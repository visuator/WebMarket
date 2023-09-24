using Microsoft.AspNetCore.Mvc;

using WebMarket.Models;

namespace WebMarket.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel model, CancellationToken token = default)
        {
            return Ok();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderStatus([FromRoute] Guid orderId, CancellationToken token = default)
        {
            return Ok();
        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> ReceiveOrder([FromRoute] Guid orderId, CancellationToken token = default)
        {
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> CancelOrder([FromRoute] Guid orderId, CancellationToken token = default)
        {
            return Ok();
        }
    }
}
