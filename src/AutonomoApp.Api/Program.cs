using AutonomoApp.Api.Configuration;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<AutonomoAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddWebApiConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();
builder.Services.ResolveDependencies();

var app = builder.Build();

app.UseApiConfig(app.Environment);

//app.UseSwagger();
//app.UseSwaggerUI();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider>();
app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.UseApiConfig(app.Environment);

app.Run();
