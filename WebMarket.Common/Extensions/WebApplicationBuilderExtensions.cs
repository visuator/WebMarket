using MassTransit;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

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

                if (builder.Environment.IsDevelopment())
                    opt.IncludeErrorDetails = true;
                opt.Audience = options.Audience;
                opt.ClaimsIssuer = options.Issuer;
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

        public static void ConfigureDbContext<TDbContext>(this WebApplicationBuilder builder, Assembly asm) where TDbContext : DbContext
        {
            builder.Services.AddDbContext<TDbContext>(opt =>
            {
                var connection = builder.Configuration.GetConnectionString("Database");
                opt.UseNpgsql(connection, npgsql =>
                {
                    npgsql.MigrationsAssembly(asm.FullName);
                });
                opt.AddInterceptors(new EntityInterceptor());

            });
            builder.Services.AddHostedService<DbInitHostedService<TDbContext>>();
        }

        public static void ConfigureMassTransit(this WebApplicationBuilder builder, Assembly asm)
        {
            builder.Services.Configure<RabbitMqTransportOptions>(builder.Configuration.GetSection("RabbitMq").Bind);
            builder.Services.AddMassTransit(opt =>
            {
                opt.AddConsumers(asm);
                opt.UsingRabbitMq((ctx, rabbitMq) =>
                {
                    rabbitMq.ConfigureEndpoints(ctx);
                });
            });
        }

        public static void ConfigureInfrastructure(this WebApplicationBuilder builder, Assembly asm)
        {
            builder.Services.AddAutoMapper(asm);
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
            builder.Services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Name = HeaderNames.Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                setup.AddSecurityRequirement(new() { { jwtSecurityScheme, Array.Empty<string>() } });
            });
        }
    }
}
