using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using ProductService.Entities;
using ProductService.Storages;

using WebMarket.Common.Messages;
using WebMarket.Common.Services;

namespace ProductService.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ProductDbContext dbContext, IMapper mapper, ILogger<CategoryService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Add(AddCategory message, CancellationToken token = default)
        {
            var entity = _mapper.Map<Category>(message);
            await _dbContext.Categories.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Category added: {id}", entity.Id);
        }

        public async Task<GetCategoriesResult> GetAll(GetCategories message, CancellationToken token = default)
        {
            var result = await _dbContext.Categories.AsNoTracking().Where(x => x.UserId == message.UserId).ApplyOrdering(x => x.Name, message).ProjectTo<GetCategoriesResult.CategoryDto>(_mapper.ConfigurationProvider).ToListAsync(token);
            return new() { Categories = result };
        }
    }
}
