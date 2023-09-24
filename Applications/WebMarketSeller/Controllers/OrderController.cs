using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

namespace WebMarketSeller.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPatch("{orderId}/build")]
        public async Task<IActionResult> Build([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new BuildOrder() { OrderId = orderId }, token);
            return Ok();
        }
    }
}
