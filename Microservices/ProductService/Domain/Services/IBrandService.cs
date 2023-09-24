using ProductService.Entities;

using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public interface IBrandService
    {
        Task Add(AddBrand message, CancellationToken token = default);
        Task<GetBrandsResult> GetAll(GetBrands message, CancellationToken token = default);
    }
}
