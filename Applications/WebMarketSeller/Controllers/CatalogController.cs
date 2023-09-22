using Microsoft.AspNetCore.Mvc;

namespace WebMarketSeller.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
