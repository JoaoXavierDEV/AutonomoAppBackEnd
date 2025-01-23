using AutonomoApp.Framework.Interfaces;
using AutonomoApp.Framework.Notificacoes;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using static AutonomoApp.Identidade.Configuration.SwaggerConfig;

namespace AutonomoApp.Identidade.Configuration
{
    public static class DependencyInjectionConfig

    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if(environmentName == "Development") {

            //}



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();

            //services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
