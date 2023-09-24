using MassTransit;

using OrderService.Domain;
using OrderService.Domain.Services;
using OrderService.Storages;

using System.Reflection;

using WebMarket.Common.Extensions;
using WebMarket.Common.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService.Domain.Services.OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.ConfigureDbContext<OrderDbContext>(Assembly.GetExecutingAssembly());
builder.ConfigureInfrastructure(Assembly.GetExecutingAssembly());
builder.ConfigureMassTransit(Assembly.GetExecutingAssembly(), cfg =>
{
    cfg.AddConsumer<StatusOrderConsumer<BuildOrder>>();
    cfg.AddConsumer<StatusOrderConsumer<DeliverOrder>>();
    cfg.AddConsumer<StatusOrderConsumer<ReturnOrder>>();
    cfg.AddConsumer<StatusOrderConsumer<CancelOrder>>();
    cfg.AddConsumer<StatusOrderConsumer<ProcessOrder>>();
    cfg.AddConsumer<StatusOrderConsumer<ReceiveOrder>>();
});

var app = builder.Build();
app.Run();