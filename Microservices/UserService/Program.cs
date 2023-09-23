using MassTransit;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

using UserService.Domain.Services;
using UserService.Services;
using UserService.Storages;

using WebMarket.Common.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUserService, UserService.Domain.Services.UserService>();
builder.Services.AddHostedService<DbInitHostedService<UserDbContext>>();
builder.Services.AddLogging();
builder.Services.AddDbContext<UserDbContext>(opt =>
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