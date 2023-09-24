using ProductService.Domain.Services;
using ProductService.Storages;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService.Domain.Services.ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.ConfigureDbContext<ProductDbContext>();
builder.ConfigureInfrastructure();
builder.ConfigureMassTransit();

var app = builder.Build();
app.Run();