using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public CartController(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCart([FromQuery] GetCartProductsModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCartProducts>(model);
            var result = await _bus.Request<GetCartProducts, GetCartProductsResult>(message, token);
            return Ok(result.Message);
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToCart([FromRoute] Guid productId, CancellationToken token = default)
        {
            await _bus.Publish(new AddToCart() { ProductId = productId }, token);
            return Ok();
        }
    }
}
