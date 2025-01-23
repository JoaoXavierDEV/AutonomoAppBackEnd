﻿using System;
using System.Reflection;
using System.Text.Json;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutonomoApp.Identidade.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo()
                //{
                //    Title = "Identity API",
                //    Description = "API para registro de usuários.",
                //    Contact = new OpenApiContact() { Name = "João Xavier", Email = "joao_jfmx@outlook.com" },
                //    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                //});

                c.OperationFilter<SwaggerDefaultValues>();
                c.EnableAnnotations();
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);


            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider? provider = null)
        {
            provider = app.ApplicationServices.GetRequiredService<Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

                // Present API version in descending order
                var versionDescriptions = provider
                    .ApiVersionDescriptions
                    .OrderBy(desc => desc.ApiVersion)
                    .ToList();

                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
                options.InjectStylesheet("/docs/swagger-ui.css");

                // remover a rota padrão "swagger"
                // https://localhost:44310/swagger/index.html
                // deve mudar também em launchUrl dentro de launchSettings.json
                options.RoutePrefix = string.Empty;
                foreach (var description in versionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", "Versão: " + description.GroupName.ToUpperInvariant());
                }

            });

            return app;
        }

        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            readonly Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider provider;

            public ConfigureSwaggerOptions(Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider provider) => this.provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
            }

            static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var info = new OpenApiInfo()
                {
                    Title = "AutonomoApp IDENTIDADE RestFul ",
                    Version = description.ApiVersion.ToString(),
                    Description = "API para registro de Usuarios.",
                    Contact = new OpenApiContact() { Name = "João Xavier", Email = "joao_jfmx@outlook.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") },
                    TermsOfService = new Uri("https://opensource.org/licenses/MIT")
                };

                if (description.IsDeprecated)
                {

                    info.Description += $"<p><b style=&#34;color:red;&#34;>Esta versão está obsoleta!</b></p>";

                }

                return info;
            }
        }
        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var apiDescription = context.ApiDescription;

                operation.Deprecated |= apiDescription.IsDeprecated();

                foreach (var responseType in context.ApiDescription.SupportedResponseTypes)
                {
                    var responseKey = responseType.IsDefaultResponse ? "default" : responseType.StatusCode.ToString();
                    var response = operation.Responses[responseKey];

                    foreach (var contentType in response.Content.Keys)
                        if (responseType.ApiResponseFormats.All(x => x.MediaType != contentType))
                            response.Content.Remove(contentType);
                }

                if (operation.Parameters == null)
                    return;

                foreach (var parameter in operation.Parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    parameter.Description ??= description.ModelMetadata.Description;

                    if (parameter.Schema.Default == null && description.DefaultValue != null)
                    {
                        var json = JsonSerializer.Serialize(description.DefaultValue, description.ModelMetadata.ModelType);
                        parameter.Schema.Default = OpenApiAnyFactory.CreateFromJson(json);
                    }

                    parameter.Required |= description.IsRequired;
                }
            }
        }

        public class SwaggerAuthorizedMiddleware
        {
            private readonly RequestDelegate _next;

            public SwaggerAuthorizedMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                if (context.Request.Path.StartsWithSegments("/swagger")
                    && !(context.User.Identity?.IsAuthenticated ?? false))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    // context.Response.Redirect("www.google.com"); 
                    // adicionar redirecionamento para login
                    // app.UseMiddleware linha #59
                    return;
                }

                await _next.Invoke(context);
            }
        }
    }
}