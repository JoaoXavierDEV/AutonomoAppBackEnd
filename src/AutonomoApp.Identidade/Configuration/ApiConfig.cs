using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace AutonomoApp.Identidade.Configuration
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


            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("X-Version"));
            })
            .AddMvc(options => { })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
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
        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app)
        {
            var Environment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            if (Environment.IsDevelopment())
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

            //app.MapControllers();

            return app;
        }
    }
}
