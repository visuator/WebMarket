using MassTransit;

using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IRequestClient<FindProducts> _findProductsRequest;

        public ProductController(IRequestClient<FindProducts> findProductsRequest)
        {
            _findProductsRequest = findProductsRequest;
        }

        [HttpGet()]
        public async Task<IActionResult> FindProducts([FromQuery] FindProductsModel model, CancellationToken token = default)
        {
            return Ok(await _findProductsRequest.GetResponse<FindProductsResult>(model, token));
        }
    }
}
