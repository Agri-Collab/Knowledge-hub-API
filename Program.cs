using api.Data;
using api.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
using Microsoft.OpenApi.Models;
using api.Services.Interfaces;
using AutoMapper.Internal;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();


var tempHasher = new PasswordHasher<User>();
var tempUser = new User();
string hash = tempHasher.HashPassword(tempUser, "Password@01");
Console.WriteLine("Hashed Password: " + hash);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.Internal().MethodMappingEnabled = true;
    cfg.AddMaps(typeof(MappingProfile).Assembly);
});

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0.0",
        Title = "Agri connect",
        Description = "An ASP.NET Core Web API for Agriculture knowledge hub system",
        Contact = new OpenApiContact
        {
            Name = "Agriculture knowledge hub",
            Email = "nduvho@gmail.com"
        }
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();


        string[] roleNames = { "FARMER", "AGRIMECHANIC", "ADMIN"  };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                Console.WriteLine($"Role '{roleName}' created successfully.");
            }
            else
            {
                Console.WriteLine($"Role '{roleName}' already exists.");
            }
        }
        
    }
    catch (Exception ex)
    {
        var loggerForSeeding = services.GetRequiredService<ILogger<Program>>();
        loggerForSeeding.LogError(ex, "An error occurred while seeding the database with roles.");
    }
}


var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Agri collab API v1.0.0");
    });
}
else
{
    app.UseHsts();
}

app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();