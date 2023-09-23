using Microsoft.EntityFrameworkCore;

using UserService.Services;
using UserService.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("Database");
    opt.UseNpgsql(connection);
    opt.AddInterceptors(new EntityInterceptor());
});

var app = builder.Build();
app.Run();