using CartService.Services;
using CartService.Storages;

using MassTransit;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CartDbContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("Database");
    opt.UseNpgsql(connection);
    opt.AddInterceptors(new EntityInterceptor());
});
builder.Services.Configure<RabbitMqTransportOptions>(builder.Configuration.GetSection("RabbitMq").Bind);
builder.Services.AddMassTransit(opt =>
{
    opt.UsingRabbitMq((ctx, rabbitMq) =>
    {
        rabbitMq.ConfigureEndpoints(ctx);
    });
});

var app = builder.Build();
app.Run();