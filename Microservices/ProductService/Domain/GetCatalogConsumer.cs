using MassTransit;

using ProductService.Domain.Services;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class GetCatalogConsumer : IConsumer<GetCatalog>
    {
        private readonly IProductService _productService;

        public GetCatalogConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<GetCatalog> context)
        {
            var result = await _productService.GetCatalog(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
