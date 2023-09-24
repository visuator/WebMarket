using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System.Reflection;

using WebMarket.Common.Infrastructure;
using WebMarket.Common.Options;
using WebMarket.Common.Services;

namespace WebMarket.Common.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization();
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)).Bind);
            builder.Services.AddAuthentication().AddJwtBearer(opt =>
            {
                var options = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
                if (options is null) throw new Exception("JwtOptions is empty");

                opt.Audience = options.Audience;
                opt.TokenValidationParameters = new()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,

                    ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                    ValidAudience = options.Audience,
                    ValidIssuer = options.Issuer,
                    IssuerSigningKey = options.SecurityKey
                };
            });
        }

        public static void ConfigureDbContext<TDbContext>(this WebApplicationBuilder builder) where TDbContext : DbContext
        {
            builder.Services.AddDbContext<TDbContext>(opt =>
            {
                var connection = builder.Configuration.GetConnectionString("Database");
                opt.UseNpgsql(connection);
                opt.AddInterceptors(new EntityInterceptor());
            });
            builder.Services.AddHostedService<DbInitHostedService<TDbContext>>();
        }

        public static void ConfigureMassTransit(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<RabbitMqTransportOptions>(builder.Configuration.GetSection("RabbitMq").Bind);
            builder.Services.AddMassTransit(opt =>
            {
                opt.AddConsumers(Assembly.GetExecutingAssembly());
                opt.UsingRabbitMq((ctx, rabbitMq) =>
                {
                    rabbitMq.ConfigureEndpoints(ctx);
                });
            });
        }

        public static void ConfigureInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddLogging();
        }

        public static void ConfigureApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<AuthenticatedActionFilter>();
            builder.Services.AddControllers(opt =>
            {
                opt.Filters.AddService<AuthenticatedActionFilter>();
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
