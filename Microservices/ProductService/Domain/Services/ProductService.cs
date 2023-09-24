using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using ProductService.Entities;
using ProductService.Storages;

using WebMarket.Common.Messages;
using WebMarket.Common.Services;

namespace ProductService.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ProductDbContext dbContext, IMapper mapper, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FindProductsResult> FindProducts(FindProducts message, CancellationToken token = default)
        {
            var query = _dbContext.Products.AsNoTracking().Include(x => x.User).Include(x => x.Brand).Include(x => x.Category).ApplyOrdering(x => x.Name, message).AsQueryable();
            if (message.CategoryId is not null)
                query.Where(x => x.CategoryId == message.CategoryId);
            if (!string.IsNullOrEmpty(message.Pattern))
                query.Where(x => x.Name.Contains(message.Pattern));

            var result = await query.ProjectTo<FindProductsResult.ProductDto>(_mapper.ConfigurationProvider).ToListAsync(token);
            return new() { Products = result };
        }

        public async Task Add(AddProduct message, CancellationToken token = default)
        {
            var entity = _mapper.Map<Product>(message);
            await _dbContext.Products.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Product added: {id}", entity.Id);
        }
    }
}
