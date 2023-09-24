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
        private readonly IRequestClient<LoginUser> _loginUserRequest;
        private readonly IMapper _mapper;

        public AccountController(IPublishEndpoint publish, IMapper mapper, IRequestClient<LoginUser> loginUserRequest)
        {
            _publish = publish;
            _mapper = mapper;
            _loginUserRequest = loginUserRequest;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateUser>(model);
            await _publish.Publish(message, token);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<LoginUser>(model);
            return Ok(await _loginUserRequest.GetResponse<LoginUserResult>(message, token));
        }
    }
}
