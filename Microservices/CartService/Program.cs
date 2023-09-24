using CartService.Domain.Services;
using CartService.Storages;

using MassTransit;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

using WebMarket.Common.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUserProductService, UserProductService>();
builder.Services.AddHostedService<DbInitHostedService<CartDbContext>>();
builder.Services.AddDbContext<CartDbContext>(opt =>
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