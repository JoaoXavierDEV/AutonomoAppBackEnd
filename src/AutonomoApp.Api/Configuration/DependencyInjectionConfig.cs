using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Data.Context;
using AutonomoApp.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ASPNET.Api.Configuration
{
    public static class DependencyInjectionConfig

    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AutonomoAppContext>();
            // services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //services.AddScoped<INotificador, Notificador>();
            //services.AddScoped<IFornecedorService, FornecedorService>();
            //services.AddScoped<IProdutoService, ProdutoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
