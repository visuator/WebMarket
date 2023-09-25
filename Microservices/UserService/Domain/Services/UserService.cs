using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using UserService.Domain.Exceptions;
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

        public async Task<UserCreated> Create(CreateUser message, CancellationToken token = default)
        {
            var exists = await _dbContext.Users.AsNoTracking().Where(x => x.Email == message.Email).AnyAsync(token);
            if (exists) throw new UserAlreadyExistsException();

            var entity = _mapper.Map<CreateUser, User>(message, opt => opt.AfterMap((src, dst) =>
            {
                var (hash, salt) = HashHelper.Encrypt(src.Password);
                dst.PasswordHash = hash;
                dst.PasswordSalt = salt;
            }));
            await _dbContext.Users.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("User created: {id}", entity.Id);

            return _mapper.Map<UserCreated>(entity);
        }

        public async Task<LoginUserResult> Login(LoginUser message, CancellationToken token = default)
        {
            var user = await _dbContext.Users.Include(x => x.Sessions).Where(x => x.Email.Trim() == message.Email.Trim()).SingleOrDefaultAsync(token);
            if (user is null) throw new UserNotFoundException();
            if (!HashHelper.Encrypt(message.Password, user.PasswordSalt).SequenceEqual(user.PasswordHash)) throw new UserNotFoundException();

            var (expiration, jwtToken) = GenerateJwt(user);
            var refreshToken = HashHelper.RandomToken();
            user.Sessions.Add(new() { RefreshToken = refreshToken, AccessToken = jwtToken, ExpiresAt = expiration });
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Session created for user: {id}", user.Id);
            return new() { AccessToken = jwtToken, ExpiresAt = expiration, RefreshToken = refreshToken };
        }

        public async Task<LoginUserResult> Refresh(RefreshUser message, CancellationToken token = default)
        {
            var session = await _dbContext.Sessions.Include(x => x.User).Where(x => x.RefreshToken == message.RefreshToken).SingleOrDefaultAsync(token);
            if (session is null) throw new UserNotFoundException();

            var (expiration, jwtToken) = GenerateJwt(session.User);
            session.AccessToken = jwtToken;
            session.ExpiresAt = expiration;
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Session updated: {token}", message.RefreshToken);
            return new() { AccessToken = jwtToken, ExpiresAt = expiration, RefreshToken = message.RefreshToken };
        }

        private (DateTime Expiration, string AccessToken) GenerateJwt(User user)
        {
            var now = DateTime.UtcNow;
            var expiration = now.Add(_jwtOptions.Expiration);
            var jwtToken = new JwtSecurityTokenHandler().CreateEncodedJwt(_jwtOptions.Issuer, _jwtOptions.Audience, new ClaimsIdentity(new List<Claim>() { new(ClaimTypes.Sid, user.Id.ToString()) }), null, expiration, now, new SigningCredentials(_jwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256));

            return (expiration, jwtToken);
        }
    }
}
