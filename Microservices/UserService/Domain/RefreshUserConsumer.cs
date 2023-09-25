using MassTransit;

using UserService.Domain.Exceptions;
using UserService.Domain.Services;

using WebMarket.Common.Messages;

namespace UserService.Domain
{
    public class RefreshUserConsumer : IConsumer<RefreshUser>
    {
        private readonly IUserAuthService _userAuthService;

        public RefreshUserConsumer(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        public async Task Consume(ConsumeContext<RefreshUser> context)
        {
            try
            {
                var result = await _userAuthService.Refresh(context.Message, context.CancellationToken);
                await context.RespondAsync(result);
            }
            catch (UserNotFoundException) { await context.RespondAsync(new UserNotFound()); }
        }
    }
}
