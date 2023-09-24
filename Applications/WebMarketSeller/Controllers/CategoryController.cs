using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
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

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] AddCategoryModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddCategory>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetCategoriesModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCategories>(model);
            var result = await _bus.Request<GetCategories, GetCategoriesResult>(message, token);
            return Ok(result.Message);
        }
    }
}
