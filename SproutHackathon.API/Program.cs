using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SproutHackathon.Business.LogicCollection.EmployeeBusiness;
using SproutHackathon.DataAccess.Contexts;
using SproutHackathon.DataAccess.Repositories.Note;
using SproutHackathon.Services.Helpers;
using SproutHackathon.Services.ServiceCollection.AuthService;
using SproutHackathon.Services.ServiceCollection.EmployeeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

builder.Services.AddDbContext<SproutDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                o.MetadataAddress = "https://sso-test-i1-admin.sprout.ph/realms/justin-local/.well-known/openid-configuration";
                o.Authority = "https://sso-test-i1-admin.sprout.ph/realms/justin-local";
                o.Audience = "account";
            });

builder.Services.AddScoped<INoteBusiness, NoteBusiness>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

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
app.UseAuthentication(); // ← Add this
app.UseAuthorization();  // ← Already implicitly needed
app.MapControllers();

app.Run();
