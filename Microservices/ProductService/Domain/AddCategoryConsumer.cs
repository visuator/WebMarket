using MassTransit;

using ProductService.Domain.Services;

using WebMarket.Common.Messages;

namespace ProductService.Domain
{
    public class AddCategoryConsumer : IConsumer<AddCategory>
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryConsumer(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Consume(ConsumeContext<AddCategory> context)
        {
            await _categoryService.Add(context.Message, context.CancellationToken);
        }
    }
}
