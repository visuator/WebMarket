using WebMarket.Common.Messages;

namespace UserService.Domain.Services
{
    public interface IUserAuthService
    {
        Task<LoginUserResult> Login(LoginUser model, CancellationToken token = default);
    }
}
