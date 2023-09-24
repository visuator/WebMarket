using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public OrderController(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateOrder>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderStatus([FromRoute] Guid orderId, CancellationToken token = default)
        {
            var result = await _bus.Request<GetOrderStatus, GetOrderStatusResult>(new GetOrderStatus() { OrderId = orderId }, token);
            return Ok(result.Message);
        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> ReceiveOrder([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new ReceiveOrder() { OrderId = orderId }, token);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> CancelOrder([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new CancelOrder() { OrderId = orderId }, token);
            return Ok();
        }
    }
}
