using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public interface IProductService
    {
        Task<ProductCreated> Add(AddProduct message, CancellationToken token = default);
        Task<FindProductsResult> FindProducts(FindProducts message, CancellationToken token = default);
        Task<GetCatalogResult> GetCatalog(GetCatalog message, CancellationToken token = default);
    }
}
