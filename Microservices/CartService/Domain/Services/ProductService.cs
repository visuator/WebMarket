using AutoMapper;

using CartService.Entities;
using CartService.Storages;

using WebMarket.Common.Messages;

namespace CartService.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly CartDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(CartDbContext dbContext, IMapper mapper, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Add(ProductCreated message, CancellationToken token = default)
        {
            var entity = _mapper.Map<Product>(message);

            await _dbContext.Products.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Product duplicated with id: {id}", entity.Id);
        }
    }
}
