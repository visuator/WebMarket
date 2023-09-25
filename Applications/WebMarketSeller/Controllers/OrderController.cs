using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
    /// <summary>
    /// Контроллер работы с заказами
    /// </summary>
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

        /// <summary>
        /// Обработка товара заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="productId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPatch("{orderId}/{productId}/process")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Process([FromRoute] Guid orderId, [FromRoute] Guid productId, CancellationToken token = default)
        {
            await _bus.Publish(new ProcessOrderProduct() { OrderId = orderId, ProductId = productId }, token);
            return Ok();
        }

        /// <summary>
        /// Сборка товара заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="productId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPatch("{orderId}/{productId}/build")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Build([FromRoute] Guid orderId, [FromRoute] Guid productId, CancellationToken token = default)
        {
            await _bus.Publish(new BuildOrderProduct() { OrderId = orderId, ProductId = productId }, token);
            return Ok();
        }

        /// <summary>
        /// Возврат товара заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="productId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpDelete("{orderId}/{productId}/return")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Return([FromRoute] Guid orderId, [FromRoute] Guid productId, CancellationToken token = default)
        {
            await _bus.Publish(new ReturnOrderProduct() { OrderId = orderId, ProductId = productId }, token);
            return Ok();
        }

        /// <summary>
        /// Получение всех активных заказов
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetOrdersModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetSellerOrders>(model);
            var result = await _bus.Request<GetSellerOrders, GetSellerOrdersResult>(message, token);
            return Ok(result.Message);
        }
    }
}
