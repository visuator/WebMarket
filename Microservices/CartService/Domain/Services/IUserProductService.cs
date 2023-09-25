using WebMarket.Common.Messages;

namespace CartService.Domain.Services
{
    public interface IUserProductService
    {
        Task Remove(OrderCreated message, CancellationToken token = default);
        Task Add(AddToCart message, CancellationToken token = default);
        Task<GetCartProductsResult> GetAll(GetCartProducts message, CancellationToken token = default);
    }
}
