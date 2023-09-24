using AutoMapper;

using CartService.Entities;
using CartService.Storages;

using WebMarket.Common.Messages;

namespace CartService.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly CartDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(CartDbContext dbContext, IMapper mapper, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Create(UserCreated message, CancellationToken token = default)
        {
            var entity = _mapper.Map<User>(message);

            await _dbContext.Users.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("User duplicated with id: {id}", entity.Id);
        }
    }
}
