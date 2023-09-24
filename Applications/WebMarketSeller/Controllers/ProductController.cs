using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Controllers
{
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

        [HttpPost()]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<AddProduct>(model);
            await _bus.Publish(message, token);
            return Ok();
        }
    }
}
