using AutonomoApp.WebApi.Configuration;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.AddWebApiConfig();

builder.Services.AddDbContext<AutonomoAppContext>(options =>
{
    string? cnn = string.Empty;
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        cnn = Environment.GetEnvironmentVariable("SQLCONNSTR_DEV");
    else
        cnn = Environment.GetEnvironmentVariable("SQLCONNSTR_PROD");


    options.UseSqlServer(cnn);
    //options.UseSqlServer(builder.Configuration.GetConnectionString($"{builder.Environment.EnvironmentName}"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddWebApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.ResolveDependencies();



var app = builder.Build();

app.UseGlobalizationConfig();

app.UseApiConfig();

app.UseSwaggerConfiguration();

app.Run();
