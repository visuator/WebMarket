using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public interface IProductService
    {
        Task Add(ProductCreated message, CancellationToken token = default);
    }
}
