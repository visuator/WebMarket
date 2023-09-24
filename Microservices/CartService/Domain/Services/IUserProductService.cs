using CartService.Entities;

using WebMarket.Common.Messages;

namespace CartService.Domain.Services
{
    public interface IUserProductService
    {
        Task Add(AddToCart model, CancellationToken token = default);
        Task<GetCartProductsResult> GetAll(GetCartProducts message, CancellationToken token = default);
    }
}
