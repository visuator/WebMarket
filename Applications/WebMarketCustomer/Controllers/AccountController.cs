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
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public AccountController(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateUser>(model);
            await _bus.Publish(message, token);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<LoginUser>(model);
            var result = await _bus.Request<LoginUser, LoginUserResult>(message, token);
            return Ok(result.Message);
        }


        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<RefreshUser>(model);
            var result = await _bus.Request<RefreshUser, LoginUserResult>(message, token);
            return Ok(result.Message);
        }
    }
}
