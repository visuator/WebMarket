using MassTransit;

using ProductService.Domain.Services;
using ProductService.Entities;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class AddBrandConsumer : IConsumer<AddBrand>
    {
        private readonly IBrandService _brandService;

        public AddBrandConsumer(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task Consume(ConsumeContext<AddBrand> context)
        {
            await _brandService.Add(context.Message, context.CancellationToken);
        }
    }
}
