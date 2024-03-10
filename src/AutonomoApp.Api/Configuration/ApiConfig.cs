using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using AutonomoApp.WebApi.Configuration;
using AutonomoApp.Data.Context;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using AutonomoApp.WebApi.Extensions;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

namespace AutonomoApp.WebApi.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                // using Microsoft.AspNetCore.Mvc.Formatters;
                // options.RespectBrowserAcceptHeader = true;
                //options.OutputFormatters.RemoveType<StringOutputFormatter>();
                //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            }).AddJsonOptions(op =>
            {
                //op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
               // .AddXmlDataContractSerializerFormatters();
            

            services.AddApiVersioning(op =>
            {
                op.DefaultApiVersion = new ApiVersion(1, 0);
                op.AssumeDefaultVersionWhenUnspecified = true;
                op.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(op =>
            {
                op.GroupNameFormat = "'v'VVV";
                op.DefaultApiVersion = new ApiVersion(1, 0);
                op.SubstituteApiVersionInUrl = true;
                op.AssumeDefaultVersionWhenUnspecified = true;
            });


            services.Configure<ApiBehaviorOptions>(
                op =>
                {
                    op.SuppressModelStateInvalidFilter = true;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                
                //options.AddPolicy("Production",
                //    builder =>
                //        builder
                //        .AllowAnyOrigin()
                //        .AllowAnyMethod()
                //        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            //.WithMethods("GET")
                            .WithMethods("")
                            //.WithOrigins("https://autonomoappwebapi.azurewebsites.net")
                            .WithOrigins("https://joaojfmx-001-site1.ctempurl.com")
                            .WithOrigins("https://joaojfmx-001-site2.ctempurl.com")
                            .WithOrigins("http://joaojfmx-001-site2.ctempurl.com")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .AllowAnyHeader());
            });
            return services;
        }
        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // funciona em modo dev, refatorar
                //app.UseCors("Production");
                app.UseCors("Development");
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            //app.UseMiddleware<ExceptionMiddleware>();

            // vai redirecionar automaticamente para https
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });


            return app;
        }
    }
}
