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

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] AddBrandModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddBrand>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetBrandsModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetBrands>(model);
            var result = await _bus.Request<GetBrands, GetBrandsResult>(message, token);
            return Ok(result.Message);
        }
    }
}
