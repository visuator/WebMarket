using MassTransit;

using ProductService.Domain.Services;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class GetBrandsConsumer : IConsumer<GetBrands>
    {
        private readonly IBrandService _brandService;

        public GetBrandsConsumer(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task Consume(ConsumeContext<GetBrands> context)
        {
            var result = await _brandService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
