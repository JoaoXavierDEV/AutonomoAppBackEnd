using AutonomoApp.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveDependencies();
builder.Services.AddWebApiConfig(builder.Configuration);

var app = builder.Build();

app.UseApiConfig(app.Environment);

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
