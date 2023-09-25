using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
    /// <summary>
    /// Контроллер работы с категориями
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public CategoryController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет категорию
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddCategoryModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddCategory>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        /// <summary>
        /// Получает все категории
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetCategoriesModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCategories>(model);
            var result = await _bus.Request<GetCategories, GetCategoriesResult>(message, token);
            return Ok(result.Message);
        }
    }
}
