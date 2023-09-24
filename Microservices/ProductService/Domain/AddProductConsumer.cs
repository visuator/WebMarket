using MassTransit;

using ProductService.Domain.Services;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class AddProductConsumer : IConsumer<AddProduct>
    {
        private readonly IProductService _productService;

        public AddProductConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<AddProduct> context)
        {
            await _productService.Add(context.Message, context.CancellationToken);
        }
    }
}
