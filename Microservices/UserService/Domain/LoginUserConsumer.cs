using MassTransit;

using UserService.Domain.Exceptions;
using UserService.Domain.Services;

using WebMarket.Common.Messages;

namespace UserService.Domain
{
    public class LoginUserConsumer : IConsumer<LoginUser>
    {
        private readonly IUserAuthService _userService;

        public LoginUserConsumer(IUserAuthService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<LoginUser> context)
        {
            try
            {
                var model = await _userService.Login(context.Message, context.CancellationToken);
                await context.RespondAsync(model);
            }
            catch (UserNotFoundException) { await context.RespondAsync(new UserNotFound()); }
        }
    }
}
