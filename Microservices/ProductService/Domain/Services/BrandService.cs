using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using ProductService.Entities;
using ProductService.Storages;

using WebMarket.Common.Messages;
using WebMarket.Common.Services;

namespace ProductService.Domain.Services
{
    public class BrandService : IBrandService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandService> _logger;

        public BrandService(ProductDbContext dbContext, IMapper mapper, ILogger<BrandService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Add(AddBrand message, CancellationToken token = default)
        {
            var entity = _mapper.Map<Brand>(message);
            await _dbContext.Brands.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Brand added: {id}", entity.Id);
        }

        public async Task<GetBrandsResult> GetAll(GetBrands message, CancellationToken token = default)
        {
            var result = await _dbContext.Brands.AsNoTracking().Where(x => x.UserId == message.UserId).ApplyOrdering(x => x.Name, message).ProjectTo<GetBrandsResult.BrandDto>(_mapper.ConfigurationProvider).ToListAsync(token);
            return new() { Brands = result };
        }
    }
}
