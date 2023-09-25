using AutoMapper;

using MassTransit;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Controllers
{
    /// <summary>
    /// Контроллер аккаунтов
    /// </summary>
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

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateUser>(model);
            Response result = await _bus.Request<CreateUser, UserAlreadyExists>(message, token);
            return result switch
            {
                (_, UserAlreadyExists) => BadRequest("Такой пользователь уже зарегистрирован!"),
                (_, CreateUserResult) => Ok(),
                _ => BadRequest(),
            };
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginUserResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<LoginUser>(model);
            var result = await _bus.Request<LoginUser, LoginUserResult>(message, token);
            return Ok(result.Message);
        }

        /// <summary>
        /// Обновление сессии
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("refresh")]
        [ProducesResponseType(typeof(LoginUserResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Refresh([FromBody] RefreshUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<RefreshUser>(model);
            var result = await _bus.Request<RefreshUser, LoginUserResult>(message, token);
            return Ok(result.Message);
        }
    }
}
