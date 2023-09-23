using Microsoft.EntityFrameworkCore;

using ProductService.Services;
using ProductService.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("Database");
    opt.UseNpgsql(connection);
    opt.AddInterceptors(new EntityInterceptor());
});

var app = builder.Build();
app.Run();