using MassTransit;

using Microsoft.EntityFrameworkCore;

using ProductService.Domain.Services;
using ProductService.Storages;

using System.Reflection;

using WebMarket.Common.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IProductService, ProductService.Domain.Services.ProductService>();
builder.Services.AddHostedService<DbInitHostedService<ProductDbContext>>();
builder.Services.AddDbContext<ProductDbContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("Database");
    opt.UseNpgsql(connection);
    opt.AddInterceptors(new EntityInterceptor());
});
builder.Services.Configure<RabbitMqTransportOptions>(builder.Configuration.GetSection("RabbitMq").Bind);
builder.Services.AddMassTransit(opt =>
{
    opt.AddConsumers(Assembly.GetExecutingAssembly());
    opt.UsingRabbitMq((ctx, rabbitMq) =>
    {
        rabbitMq.ConfigureEndpoints(ctx);
    });
});

var app = builder.Build();
app.Run();