using UserService.Domain.Services;
using UserService.Storages;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService.Domain.Services.UserService>();
builder.Services.AddScoped<IUserAuthService, UserService.Domain.Services.UserService>();

builder.ConfigureDbContext<UserDbContext>();
builder.ConfigureInfrastructure();
builder.ConfigureMassTransit();

var app = builder.Build();
app.Run();