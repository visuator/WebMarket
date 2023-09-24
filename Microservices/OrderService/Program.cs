using OrderService.Domain.Services;
using OrderService.Storages;

using System.Reflection;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService.Domain.Services.OrderService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.ConfigureDbContext<OrderDbContext>(Assembly.GetExecutingAssembly());
builder.ConfigureInfrastructure(Assembly.GetExecutingAssembly());
builder.ConfigureMassTransit(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.Run();