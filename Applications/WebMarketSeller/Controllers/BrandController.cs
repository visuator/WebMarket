using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
    /// <summary>
    /// Контроллер работы с марками
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public BrandController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет марку
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddBrandModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddBrand>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        /// <summary>
        /// Получает все марки продавца
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(GetBrandsResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetBrandsModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetBrands>(model);
            var result = await _bus.Request<GetBrands, GetBrandsResult>(message, token);
            return Ok(result.Message);
        }
    }
}
