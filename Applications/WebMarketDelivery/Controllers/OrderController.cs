using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketDelivery.Models;

namespace WebMarketDelivery.Controllers
{
    /// <summary>
    /// Контроллер курьера
    /// </summary>
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

        /// <summary>
        /// Получает список активных заказов
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(GetCarrierOrdersResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrders([FromQuery] GetCarrierOrdersModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCarrierOrders>(model);
            var result = await _bus.Request<GetCarrierOrders, GetCarrierOrdersResult>(message);
            return Ok(result.Message);
        }

        /// <summary>
        /// Получает информацию о содержимом заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet("{orderId}/package")]
        [ProducesResponseType(typeof(GetOrderPackageInfoResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderPackageInfo([FromRoute] Guid orderId, CancellationToken token = default)
        {
            var result = await _bus.Request<GetOrderPackageInfo, GetOrderPackageInfoResult>(new GetOrderPackageInfo() { OrderId = orderId }, token);
            return Ok(result.Message);
        }

        /// <summary>
        /// Доставка заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPatch("{orderId}/deliver")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Deliver([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new DeliverOrder() { OrderId = orderId }, token);
            return Ok();
        }

        /// <summary>
        /// Возврат заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpDelete("{orderId}/return")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Return([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new ReturnOrder() { OrderId = orderId }, token);
            return Ok();
        }

        /// <summary>
        /// Сборка заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPatch("{orderId}/build")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Build([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new BuildOrder() { OrderId = orderId }, token);
            return Ok();
        }
    }
}
