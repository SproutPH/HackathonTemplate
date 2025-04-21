using Microsoft.OpenApi.Models;
using SproutHackathon.BLL.LogicCollection.EmployeeBusiness;
using SproutHackathon.Services.Helpers;
using SproutHackathon.Services.ServiceCollection.AuthService;
using SproutHackathon.Services.ServiceCollection.EmployeeService;

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
builder.Services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
builder.Services.AddScoped<IAuthService, AuthService>();
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
