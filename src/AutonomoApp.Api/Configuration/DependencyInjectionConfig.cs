using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Notificacoes;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Context;
using AutonomoApp.Data.Repository;
using AutonomoApp.Data.Repository.FakeRepository;
using AutonomoApp.WebApi.Extensions;
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
            // TODO: pegar variavel de ambiente: RepositoryFaker
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if(environmentName == "Development") {
            //    // Development
            //    services.AddScoped<AutonomoAppContext>();
            //    // REPOSITORY
            //    services.AddScoped<ICategoriaRepository, CategoriaFakeRepository>();
            //    services.AddScoped<IServicoRepository, ServicoFakeRepository>();

            //    services.AddScoped<IPessoaFisicaRepository, PessoaFisicaFakeRepository>();
            //    services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaFakeRepository>();

            //    // SERVICES
            //    services.AddScoped<IServicoService, ServicoService>(); 
            //}
            if(environmentName == "Development")
            {
                // Production
                // REPOSITORY
                services.AddScoped<AutonomoAppContext>();
                services.AddScoped<ICategoriaRepository, CategoriaRepository>();
                services.AddScoped<IServicoRepository, ServicoRepository>();
                // SERVICES
                services.AddScoped<IServicoService, ServicoService>();

            }
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
