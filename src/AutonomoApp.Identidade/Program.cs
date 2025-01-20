using AutonomoApp.Identidade.Configuration;
using AutonomoApp.Identidade.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();


builder.Services.AddIdentityConfiguration(builder);

var tt = builder.Configuration.GetConnectionString($"{builder.Environment.EnvironmentName}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string? cnn = string.Empty;
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        cnn = Environment.GetEnvironmentVariable("SQLCONNSTR_DEV");
    else
        cnn = Environment.GetEnvironmentVariable("SQLCONNSTR_PROD");

    
    //options.UseSqlServer(cnn);
    options.UseSqlServer(builder.Configuration.GetConnectionString($"{builder.Environment.EnvironmentName}"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerConfiguration();



var app = builder.Build();

app.UseSwaggerConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
