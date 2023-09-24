using MassTransit;

using ProductService.Domain.Services;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class FindProductsConsumer : IConsumer<FindProducts>
    {
        private readonly IProductService _productService;

        public FindProductsConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<FindProducts> context)
        {
            var model = await _productService.FindProducts(context.Message, context.CancellationToken);
            await context.RespondAsync(model);
        }
    }
}
