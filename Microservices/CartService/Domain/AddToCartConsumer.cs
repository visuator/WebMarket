using CartService.Domain.Services;

using MassTransit;

using WebMarket.Common.Messages;

namespace CartService.Domain
{
    public class AddToCartConsumer : IConsumer<AddToCart>
    {
        private readonly IUserProductService _userProductService;

        public AddToCartConsumer(IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        public async Task Consume(ConsumeContext<AddToCart> context)
        {
            await _userProductService.Add(context.Message, context.CancellationToken);
        }
    }
}
