using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public interface IOrderProductService
    {
        Task SetStatus(StatusOrderProduct message, CancellationToken token = default);
    }
}
