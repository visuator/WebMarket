using WebMarket.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApi();
builder.ConfigureAuthentication();
builder.ConfigureInfrastructure();
builder.ConfigureMassTransit();

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
