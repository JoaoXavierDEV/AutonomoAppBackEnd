using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Context;
using AutonomoApp.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutonomoApp.WebApi.Configuration
{
    public static class DependencyInjectionConfig

    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AutonomoAppContext>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IServicoService, ServicoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
