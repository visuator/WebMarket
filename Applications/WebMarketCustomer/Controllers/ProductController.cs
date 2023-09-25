using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    /// <summary>
    /// Контроллер работы с товарами
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ProductController(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        /// <summary>
        /// Поиск товаров
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(FindProductsResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindProducts([FromQuery] FindProductsModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<FindProducts>(model);
            var result = await _bus.Request<FindProducts, FindProductsResult>(model, token);
            return Ok(result.Message);
        }
    }
}
