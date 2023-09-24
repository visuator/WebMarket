using WebMarket.Common.Messages;

namespace UserService.Domain.Services
{
    public interface IUserService
    {
        Task Create(CreateUser message, CancellationToken token = default);
    }
}
