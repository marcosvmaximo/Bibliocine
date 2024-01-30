using Bibliocine.API.Configurations;
using Bibliocine.API.Configurations.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServicesExtensions(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Version 1.0");
});


app.MapControllers();
app.Run();