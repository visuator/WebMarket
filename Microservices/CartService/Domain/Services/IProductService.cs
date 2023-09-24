using WebMarket.Common.Messages;

namespace CartService.Domain.Services
{
    public interface IProductService
    {
        Task Add(ProductCreated message, CancellationToken token = default);
    }
}
