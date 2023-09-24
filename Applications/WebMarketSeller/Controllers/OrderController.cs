using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
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

        [HttpPatch("{orderId}/build")]
        public async Task<IActionResult> Build([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new BuildOrder() { OrderId = orderId }, token);
            return Ok();
        }

        [HttpPatch("{orderId}/process")]
        public async Task<IActionResult> Process([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new ProcessOrder() { OrderId = orderId }, token);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetOrdersModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetSellerOrders>(model);
            var result = await _bus.Request<GetSellerOrders, GetSellerOrdersResult>(message, token);
            return Ok(result.Message);
        }
    }
}
