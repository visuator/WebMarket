using AutoMapper;
using AutoMapper.QueryableExtensions;

using CartService.Entities;
using CartService.Storages;

using Microsoft.EntityFrameworkCore;

using WebMarket.Common.Messages;
using WebMarket.Common.Services;

namespace CartService.Domain.Services
{
    public class UserProductService : IUserProductService
    {
        private readonly CartDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserProductService> _logger;

        public UserProductService(CartDbContext dbContext, IMapper mapper, ILogger<UserProductService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Add(AddToCart model, CancellationToken token = default)
        {
            var exists = await _dbContext.UserProducts.Where(x => x.UserId == model.UserId && x.ProductId == model.ProductId).SingleOrDefaultAsync(token);
            if (exists is not null)
            {
                exists.Count++;
                _logger.LogInformation("Item count incremented: {id}", exists.ProductId);
            }
            else
            {
                var entity = _mapper.Map<UserProduct>(model);
                await _dbContext.UserProducts.AddAsync(entity, token);
                _logger.LogInformation("Item added to cart: {id}", entity.ProductId);
            }
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<GetCartProductsResult> GetAll(GetCartProducts message, CancellationToken token = default)
        {
            var result = await _dbContext.UserProducts.AsNoTracking().Where(x => x.UserId == message.UserId).ApplyOrdering(x => x.CreatedAt, message).ProjectTo<GetCartProductsResult.UserProductDto>(_mapper.ConfigurationProvider).ToListAsync(token);
            return new() { Products = result };
        }
    }
}
