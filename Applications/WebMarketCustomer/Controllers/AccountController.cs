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
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IPublishEndpoint _publish;
        private readonly IMapper _mapper;

        public AccountController(IPublishEndpoint publish, IMapper mapper)
        {
            _publish = publish;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateUser>(model);
            await _publish.Publish(message, token);
            return Ok();
        }
    }
}
