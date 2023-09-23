using MassTransit;

using Microsoft.EntityFrameworkCore;

using OrderService.Storages;

using WebMarket.Common.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddHostedService<DbInitHostedService<OrderDbContext>>();
builder.Services.AddDbContext<OrderDbContext>(opt =>
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