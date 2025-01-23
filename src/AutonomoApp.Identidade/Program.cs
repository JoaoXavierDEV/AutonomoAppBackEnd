using AutonomoApp.Identidade.Configuration;
/*using AutonomoApp.WebApi.Extensions;*/ //Resolve! Refatorar para o projeto de identidade

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();

builder.Services.AddIdentityConfiguration(builder);

builder.Services.AddWebApiConfig();

builder.Services.AddSwaggerConfiguration();

builder.Services.ResolveDependencies();

var app = builder.Build();

app.UseGlobalizationConfig();

app.UseApiConfig();

app.UseSwaggerConfiguration();

app.Run();
