using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SproutHackathon.Business.LogicCollection.EmployeeBusiness;
using SproutHackathon.DataAccess.Contexts;
using SproutHackathon.DataAccess.Repositories.Note;
using SproutHackathon.Services.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SproutHackathon.Services.ServiceCollection.Ecosystem.SproutApi;
using SproutHackathon.Services.ServiceCollection.Sprout.EmployeeService;
using SproutHackathon.Services.ServiceCollection.Sprout.AuthService;
using SproutHackathon.Business.LogicCollection.EmployeeBusiness.CompanyBusiness;
using SproutHackathon.Business.LogicCollection.CompanyBusiness;

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

    // 🔥 Add this for the Authorization button
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token (without 'Bearer' prefix)"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


// OPTIONAL: Register BLL/DAL (if you don't use DependencyInjection.cs)
builder.Services.AddScoped<ISproutApiService, SproutApiService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICompanyBusiness, CompanyBusiness>();
builder.Services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ApiRequestHelper>();
builder.Services.AddScoped<INoteBusiness, NoteBusiness>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddHttpClient();

var dbProvider = builder.Configuration["DatabaseProvider"];

builder.Services.AddDbContext<SproutDbContext>(options =>
{
    if (dbProvider == "postgres")
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    }
    else // fallback to sqlite
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    }
});

var realmUrl = builder.Configuration["RealmUrl"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                o.MetadataAddress = ".well-known/openid-configuration";
                o.Authority = "https://sso-test.sprout.ph/realms/eco-zeus";
                o.Audience = "account";
            });

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
