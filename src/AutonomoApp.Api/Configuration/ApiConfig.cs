using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using AutonomoApp.WebApi.Configuration;
using AutonomoApp.Data.Context;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace AutonomoApp.WebApi.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddApiVersioning(op =>
            {
                op.DefaultApiVersion = new ApiVersion(1,0);
                op.AssumeDefaultVersionWhenUnspecified = true;
                op.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(op =>
            {
                op.GroupNameFormat = "'v'VVV";
                op.DefaultApiVersion = new ApiVersion(1,0);
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


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .WithMethods("GET")
                            .WithOrigins("https://autonomoappwebapi.azurewebsites.net")
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
                app.UseCors("Production");
                app.UseHsts();
            }
            //app.UseMiddleware<ExceptionMiddleware>();
            
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
