using CartService.Domain.Services;
using CartService.Storages;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserProductService, UserProductService>();

builder.ConfigureDbContext<CartDbContext>();
builder.ConfigureInfrastructure();
builder.ConfigureMassTransit();

var app = builder.Build();
app.Run();