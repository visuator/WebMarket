using ProductService.Domain.Services;
using ProductService.Storages;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService.Domain.Services.ProductService>();

builder.ConfigureDbContext<ProductDbContext>();
builder.ConfigureInfrastructure();
builder.ConfigureMassTransit();

var app = builder.Build();
app.Run();