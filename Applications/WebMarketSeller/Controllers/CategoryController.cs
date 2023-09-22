using Microsoft.AspNetCore.Mvc;

namespace WebMarketSeller.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
