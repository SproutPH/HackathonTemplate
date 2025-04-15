using Microsoft.OpenApi.Models;
using SproutHackathon.BLL.Interfaces;
using SproutHackathon.BLL.Services;
using SproutHackathon.Services.Helpers;
using SproutHackathon.Services.Interfaces;
using SproutHackathon.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SproutHackathon API",
        Version = "v1"
    });
});

// OPTIONAL: Register BLL/DAL (if you don't use DependencyInjection.cs)
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ApiRequestHelper>();
builder.Services.AddHttpClient();

var app = builder.Build();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");
// Enable Swagger only in Development (optional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
