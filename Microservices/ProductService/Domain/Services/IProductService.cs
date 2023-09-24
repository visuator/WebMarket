using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public interface IProductService
    {
        Task<FindProductsResult> FindProducts(FindProducts model, CancellationToken token = default);
    }
}
