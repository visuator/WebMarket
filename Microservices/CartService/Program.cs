using CartService.Domain.Services;
using CartService.Storages;

using System.Reflection;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserProductService, UserProductService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.ConfigureDbContext<CartDbContext>(Assembly.GetExecutingAssembly());
builder.ConfigureInfrastructure(Assembly.GetExecutingAssembly());
builder.ConfigureMassTransit(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.Run();