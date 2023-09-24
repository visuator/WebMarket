using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public interface IUserService
    {
        Task Create(UserCreated message, CancellationToken token = default);
    }
}
