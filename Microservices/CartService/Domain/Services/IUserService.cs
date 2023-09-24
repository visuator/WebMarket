using WebMarket.Common.Messages;

namespace CartService.Domain.Services
{
    public interface IUserService
    {
        Task Create(UserCreated message, CancellationToken token = default);
    }
}
