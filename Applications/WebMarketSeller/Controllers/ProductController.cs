using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
    /// <summary>
    /// Контроллер работы с товарами
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public ProductController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет товар к продавцу
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddProduct>(model);
            await _bus.Publish(message, token);
            return Ok();
        }
    }
}
