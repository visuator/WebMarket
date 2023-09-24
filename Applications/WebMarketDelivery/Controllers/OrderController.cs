using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketDelivery.Models;

namespace WebMarketDelivery.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public OrderController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetOrders([FromQuery] GetCarrierOrdersModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCarrierOrders>(model);
            var result = await _bus.Request<GetCarrierOrders, GetCarrierOrdersResult>(message);
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

        [HttpDelete("{orderId}/return")]
        public async Task<IActionResult> Return([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new ReturnOrder() { OrderId = orderId }, token);
            return Ok();
        }
    }
}
