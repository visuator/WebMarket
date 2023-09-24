using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
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

        [HttpGet()]
        public async Task<IActionResult> FindProducts([FromQuery] FindProductsModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<FindProducts>(model);
            var result = await _bus.Request<FindProducts, FindProductsResult>(model, token);
            return Ok(result.Message);
        }
    }
}
