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

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetCatalogModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<GetCatalog>(model);
            var result = await _bus.Request<GetCatalog, GetCatalogResult>(message, token);
            return Ok(result.Message);
        }
    }
}
