using System.Reflection;

using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApi();
builder.ConfigureAuthentication();
builder.ConfigureInfrastructure(Assembly.GetExecutingAssembly());
builder.ConfigureMassTransit(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
