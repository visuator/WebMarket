using AutoMapper;

using OrderService.Entities;
using OrderService.Storages;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly OrderDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(OrderDbContext dbContext, IMapper mapper, ILogger<ProductService> logger)
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
