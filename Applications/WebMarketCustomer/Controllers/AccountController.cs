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
        private readonly IRequestClient<CreateUser> _createUserRequest;
        private readonly IRequestClient<LoginUser> _loginUserRequest;
        private readonly IRequestClient<RefreshUser> _refreshUserRequest;

        public AccountController(IMapper mapper, IRequestClient<CreateUser> createUserRequest, IRequestClient<LoginUser> loginUserRequest, IRequestClient<RefreshUser> refreshUserRequest)
        {
            _mapper = mapper;
            _createUserRequest = createUserRequest;
            _loginUserRequest = loginUserRequest;
            _refreshUserRequest = refreshUserRequest;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<CreateUser>(model);
            Response result = await _createUserRequest.GetResponse<CreateUserResult, UserAlreadyExists>(message, token);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<LoginUser>(model);
            Response result = await _loginUserRequest.GetResponse<LoginUserResult, UserNotFound>(message, token);
            return result switch
            {
                (_, UserNotFound) => BadRequest("Пользователь не найден и/или неправильный пароль"),
                (_, LoginUserResult e) => Ok(e),
                _ => BadRequest(),
            };
        }

        /// <summary>
        /// Обновление сессии
        /// </summary>
        /// <param name="model">Запрос</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Refresh([FromBody] RefreshUserModel model, CancellationToken token = default)
        {
            var message = _mapper.Map<RefreshUser>(model);
            Response result = await _refreshUserRequest.GetResponse<LoginUserResult, UserNotFound>(message, token);
            return result switch
            {
                (_, UserNotFound) => BadRequest("Пользователь не найден"),
                (_, LoginUserResult e) => Ok(e),
                _ => BadRequest(),
            };
        }
    }
}
