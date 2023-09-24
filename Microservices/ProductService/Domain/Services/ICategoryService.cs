using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public interface ICategoryService
    {
        Task Add(AddCategory message, CancellationToken token = default);
        Task<GetCategoriesResult> GetAll(GetCategories message, CancellationToken token = default);
    }
}
