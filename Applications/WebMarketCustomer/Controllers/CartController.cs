using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    /// <summary>
    /// Контроллер корзины товаров
    /// </summary>
    [Authorize]
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

        /// <summary>
        /// Получает список товаров
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCart([FromQuery] GetCartProductsModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCartProducts>(model);
            var result = await _bus.Request<GetCartProducts, GetCartProductsResult>(message, token);
            return Ok(result.Message);
        }

        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        /// <param name="productId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPost("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddToCart>(model);
            await _bus.Publish(message, token);
            return Ok();
        }
    }
}
