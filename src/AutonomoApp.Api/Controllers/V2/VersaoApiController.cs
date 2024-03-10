using AutonomoApp.Business.Interfaces;
using AutonomoApp.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AutonomoApp.WebApi.Controllers.V2
{
    [ApiVersion("2.1", Deprecated = false)]
    [Route("api/v{version:apiVersion}/VersaoApiController")]
    //[Produces("application/json")]
    public class VersaoApiController : MainController
    {
        public VersaoApiController(INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
        }

        [HttpGet("VersaoApi/")]
        [Produces("text/plain")]
        public string ObterVariavelDesenvolvimento()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Variável de ambiente não encontrada";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets<AutonomoAppContext>()
                .Build();

            var cnn = config.GetConnectionString($"{environmentName}") ?? "CNN Não encontrado";

            var result = environmentName + Environment.NewLine + cnn;

            return result;
        }
    }
}
