using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        private readonly IProductService _productService;

        public ProductCreatedConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            await _productService.Add(context.Message, context.CancellationToken);
        }

        public class Definition : ConsumerDefinition<ProductCreatedConsumer>
        {
            public Definition()
            {
                Endpoint(x => x.Name = $"{nameof(ProductCreated)}OrderConsumer");
            }
        }
    }
}
