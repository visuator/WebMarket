using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

namespace WebMarketDelivery.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet("{orderId}/status")]
        public async Task<IActionResult> GetOrderStatus([FromRoute] Guid orderId, CancellationToken token = default)
        {
            var result = await _bus.Request<GetOrderStatus, GetOrderStatusResult>(new GetOrderStatus() { OrderId = orderId }, token);
            return Ok(result.Message);
        }

        [HttpGet("{orderId}/package")]
        public async Task<IActionResult> GetOrderPackageInfo([FromRoute] Guid orderId, CancellationToken token = default)
        {
            var result = await _bus.Request<GetOrderPackageInfo, GetOrderPackageInfoResult>(new GetOrderPackageInfo() { OrderId = orderId }, token);
            return Ok(result.Message);
        }

        [HttpPatch("{orderId}/deliver")]
        public async Task<IActionResult> Deliver([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new DeliverOrder() { OrderId = orderId }, token);
            return Ok();
        }

        [HttpPatch("{orderId}/build")]
        public async Task<IActionResult> Build([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new BuildOrder() { OrderId = orderId }, token);
            return Ok();
        }

        [HttpDelete("{orderId}/return")]
        public async Task<IActionResult> Return([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new ReturnOrder() { OrderId = orderId }, token);
            return Ok();
        }
    }
}
