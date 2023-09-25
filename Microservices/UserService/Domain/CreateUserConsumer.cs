using MassTransit;

using UserService.Domain.Exceptions;
using UserService.Domain.Services;

using WebMarket.Common.Messages;

namespace UserService.Domain
{
    public class CreateUserConsumer : IConsumer<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserConsumer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<CreateUser> context)
        {
            try
            {
                var result = await _userService.Create(context.Message, context.CancellationToken);
                await context.Publish(result, context.CancellationToken);
                await context.RespondAsync(new CreateUserResult());
            }
            catch (UserAlreadyExistsException) { await context.RespondAsync(new UserAlreadyExists()); }
        }
    }
}
