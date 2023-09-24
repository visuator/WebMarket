using WebMarket.Common.Messages;

namespace UserService.Domain.Services
{
    public interface IUserAuthService
    {
        Task<LoginUserResult> Login(LoginUser message, CancellationToken token = default);
        Task<LoginUserResult> Refresh(RefreshUser message, CancellationToken token = default);
    }
}
