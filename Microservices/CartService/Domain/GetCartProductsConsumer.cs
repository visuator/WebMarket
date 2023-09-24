using CartService.Domain.Services;

using MassTransit;

using WebMarket.Common.Messages;

namespace CartService.Domain
{
    public class GetCartProductsConsumer : IConsumer<GetCartProducts>
    {
        private readonly IUserProductService _userProductService;

        public GetCartProductsConsumer(IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        public async Task Consume(ConsumeContext<GetCartProducts> context)
        {
            var result = await _userProductService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
