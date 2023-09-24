namespace WebMarket.Common.Infrastructure
{
    public interface IAuthenticated
    {
        Guid UserId { get; set; }
    }
}
