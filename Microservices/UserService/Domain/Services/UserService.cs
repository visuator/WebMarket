using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using UserService.Entities;
using UserService.Services;
using UserService.Storages;

using WebMarket.Common.Messages;
using WebMarket.Common.Options;

namespace UserService.Domain.Services
{
    public class UserService : IUserService, IUserAuthService
    {
        private readonly UserDbContext _dbContext;
        private readonly JwtOptions _jwtOptions;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(UserDbContext dbContext, IOptions<JwtOptions> jwtOptions, IMapper mapper, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _jwtOptions = jwtOptions.Value;
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

        public async Task<LoginUserResult> Login(LoginUser model, CancellationToken token = default)
        {
            var user = await _dbContext.Users.Include(x => x.Sessions).Where(x => x.Email.Trim() == model.Email.Trim()).SingleOrDefaultAsync(token);
            if (user is null) throw new Exception("User not found");
            var now = DateTime.UtcNow;
            var expiration = now.Add(_jwtOptions.Expiration);
            var refreshToken = HashHelper.RandomToken();
            var jwtToken = new JwtSecurityTokenHandler().CreateEncodedJwt(_jwtOptions.Issuer, _jwtOptions.Audience, new ClaimsIdentity(new List<Claim>() { new(ClaimTypes.Sid, user.Id.ToString()) }), null, expiration, now, new SigningCredentials(_jwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256));
            user.Sessions.Add(new() { RefreshToken = refreshToken, AccessToken = jwtToken, ExpiresAt = expiration });
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Session created for user: {id}", user.Id);
            return new() { AccessToken = jwtToken, ExpiresAt = expiration, RefreshToken = refreshToken };
        }
    }
}
