using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public interface IOrderService
    {
        Task Create(CreateOrder message, CancellationToken token = default);
        Task<GetOrderStatusResult> GetStatus(GetOrderStatus message, CancellationToken token = default);
        Task<GetOrderPackageInfoResult> GetPackageInfo(GetOrderPackageInfo message, CancellationToken token = default);
        Task SetStatus(StatusOrder message, CancellationToken token = default);
        Task<GetOrdersResult> GetAll(GetOrders message, CancellationToken token = default);
    }
}
