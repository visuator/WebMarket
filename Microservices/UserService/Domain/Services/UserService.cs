using AutoMapper;

using UserService.Entities;
using UserService.Services;
using UserService.Storages;

using WebMarket.Common.Messages;

namespace UserService.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(UserDbContext dbContext, IMapper mapper, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Create(CreateUser model, CancellationToken token = default)
        {
            var user = _mapper.Map<CreateUser, User>(model, opt => opt.AfterMap((src, dst) =>
            {
                var (hash, salt) = HashHelper.Encrypt(src.Password);
                dst.PasswordHash = hash;
                dst.PasswordSalt = salt;
            }));
            await _dbContext.Users.AddAsync(user, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("User created: {id}", user.Id);
        }
    }
}
