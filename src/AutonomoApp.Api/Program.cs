using AutonomoApp.WebApi.Configuration;
using AutonomoApp.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();

builder.Services.AddDbContext<AutonomoAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString($"{builder.Environment.EnvironmentName}"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddWebApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.ResolveDependencies();

var app = builder.Build();

app.UseGlobalizationConfig();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(app.Environment);
app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.Run();
