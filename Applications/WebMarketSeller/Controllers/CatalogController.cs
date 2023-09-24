using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

namespace WebMarketSeller.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly IBus _bus;

        public CatalogController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(CancellationToken token = default)
        {
            var result = await _bus.Request<GetCatalog, GetCatalogResult>(new GetCatalog(), token);
            return Ok(result.Message);
        }
    }
}
