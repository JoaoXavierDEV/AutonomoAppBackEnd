using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Context;
using AutonomoApp.Data.Repository;
using AutonomoApp.Data.Repository.FakeRepository;
using AutonomoApp.Framework.Interfaces;
using AutonomoApp.Framework.Notificacoes;
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
            // var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

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

            // REPOSITORY
            services.AddScoped<AutonomoAppContext>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ISubCategoriaRepository, SubCategoriaRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            // SERVICES
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ISubCategoriaService, SubCategoriaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
