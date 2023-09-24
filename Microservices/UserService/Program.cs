using System.Reflection;

using UserService.Domain.Services;
using UserService.Storages;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService.Domain.Services.UserService>();
builder.Services.AddScoped<IUserAuthService, UserService.Domain.Services.UserService>();

builder.ConfigureAuthentication();
builder.ConfigureDbContext<UserDbContext>(Assembly.GetExecutingAssembly());
builder.ConfigureInfrastructure(Assembly.GetExecutingAssembly());
builder.ConfigureMassTransit(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.Run();