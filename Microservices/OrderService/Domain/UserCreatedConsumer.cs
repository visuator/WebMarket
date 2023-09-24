using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        private readonly IUserService _userService;

        public UserCreatedConsumer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            await _userService.Create(context.Message, context.CancellationToken);
        }
    }
}
