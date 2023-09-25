using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
    /// <summary>
    /// Контроллер работы с каталогом
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public CatalogController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает все позиции
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(GetCatalogResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetCatalogModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCatalog>(model);
            var result = await _bus.Request<GetCatalog, GetCatalogResult>(message, token);
            return Ok(result.Message);
        }
    }
}
