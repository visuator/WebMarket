using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public interface IProductService
    {
        Task Add(AddProduct message, CancellationToken token = default);
        Task<FindProductsResult> FindProducts(FindProducts message, CancellationToken token = default);
    }
}
