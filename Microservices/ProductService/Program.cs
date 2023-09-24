using ProductService.Domain.Services;
using ProductService.Storages;

using System.Reflection;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService.Domain.Services.ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.ConfigureDbContext<ProductDbContext>(Assembly.GetExecutingAssembly());
builder.ConfigureInfrastructure(Assembly.GetExecutingAssembly());
builder.ConfigureMassTransit(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.Run();