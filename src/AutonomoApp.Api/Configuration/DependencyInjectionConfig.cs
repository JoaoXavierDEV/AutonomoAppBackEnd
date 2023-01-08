using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Context;
using AutonomoApp.Data.Repository;
using AutonomoApp.Data.Repository.FakeRepository;
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

            if(environmentName == "Development") { 
            
                services.AddScoped<AutonomoAppContext>();
                services.AddScoped<ICategoriaRepository, CategoriaFakeRepository>();
                services.AddScoped<IServicoRepository, ServicoFakeRepository>();
                services.AddScoped<IServicoService, ServicoService>();

                services.AddScoped<IPessoaFisicaRepository, PessoaFisicaFakeRepository>();
                services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaFakeRepository>();

            }
            if(environmentName == "Production")
            {
                services.AddScoped<AutonomoAppContext>();
                services.AddScoped<ICategoriaRepository, CategoriaRepository>();
                services.AddScoped<IServicoRepository, ServicoRepository>();
                services.AddScoped<IServicoService, ServicoService>();

            }
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
