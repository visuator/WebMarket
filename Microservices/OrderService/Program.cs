using OrderService.Storages;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDbContext<OrderDbContext>();
builder.ConfigureInfrastructure();
builder.ConfigureMassTransit();

var app = builder.Build();
app.Run();