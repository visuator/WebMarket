using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using ProductService.Storages;

using WebMarket.Common.Messages;

namespace ProductService.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FindProductsResult> FindProducts(FindProducts model, CancellationToken token = default)
        {
            var query = _dbContext.Products.AsNoTracking().Include(x => x.User).Include(x => x.Brand).Include(x => x.Category).AsQueryable();
            if (model.CategoryId is not null)
                query.Where(x => x.CategoryId == model.CategoryId);
            if (!string.IsNullOrEmpty(model.Pattern))
                query.Where(x => x.Name.Contains(model.Pattern));
            if (model.Descending)
                query.OrderByDescending(x => x.Name);

            var result = await query.ProjectTo<FindProductsResult.ProductDto>(_mapper.ConfigurationProvider).ToListAsync(token);
            return new() { Products = result };
        }
    }
}
