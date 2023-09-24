using MassTransit;

using ProductService.Domain.Services;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class GetCategoriesConsumer : IConsumer<GetCategories>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoriesConsumer(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Consume(ConsumeContext<GetCategories> context)
        {
            var result = await _categoryService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
