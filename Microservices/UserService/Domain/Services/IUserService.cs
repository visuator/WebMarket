using UserService.Entities;

using WebMarket.Common.Messages;

namespace UserService.Domain.Services
{
    public interface IUserService
    {
        Task<UserCreated> Create(CreateUser message, CancellationToken token = default);
    }
}
