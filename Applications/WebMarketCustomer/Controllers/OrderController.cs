using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    /// <summary>
    /// Контроллер для работы с заказами
    /// </summary>
    [Authorize]
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

        /// <summary>
        /// Создает заказ
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateOrder>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        /// <summary>
        /// Получает заказы
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrders([FromQuery] GetUserOrdersModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetUserOrders>(model);
            var result = await _bus.Request<GetUserOrders, GetUserOrdersResult>(message);
            return Ok(result.Message);
        }

        /// <summary>
        /// Получает статус заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderStatus([FromRoute] Guid orderId, CancellationToken token = default)
        {
            var result = await _bus.Request<GetOrderStatus, GetOrderStatusResult>(new GetOrderStatus() { OrderId = orderId }, token);
            return Ok(result.Message);
        }

        /// <summary>
        /// Самовывоз заказа
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPost("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReceiveOrder([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new ReceiveOrder() { OrderId = orderId }, token);
            return Ok();
        }

        /// <summary>
        /// Отменяет заказ
        /// </summary>
        /// <param name="orderId">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>

        [HttpDelete("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelOrder([FromRoute] Guid orderId, CancellationToken token = default)
        {
            await _bus.Publish(new CancelOrder() { OrderId = orderId }, token);
            return Ok();
        }
    }
}
