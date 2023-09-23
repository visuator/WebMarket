using Microsoft.EntityFrameworkCore;

using OrderService.Services;
using OrderService.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("Database");
    opt.UseNpgsql(connection);
    opt.AddInterceptors(new EntityInterceptor());
});

var app = builder.Build();
app.Run();