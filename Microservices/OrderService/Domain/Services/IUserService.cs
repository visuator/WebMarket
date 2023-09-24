using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public interface IUserService
    {
        Task Create(UserCreated message, CancellationToken token = default);
    }
}
