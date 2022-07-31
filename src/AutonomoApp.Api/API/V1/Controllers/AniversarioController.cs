using AutonomoApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Api.V1.Controllers
{
    [ApiVersion("1.01", Deprecated = true)]
    [Route("api/v{version:apiVersion}/aniversario")]
    [Produces("application/json")]
    public class AniversarioController : MainController
    {
        [HttpPost("idade/{nascimento:datetime}")]
        public ActionResult<string> ObterIdade(DateTime nascimento)
        {
            var result = DateTime.Now.Year - nascimento.Year;

            return DateTime.Now.DayOfYear < nascimento.DayOfYear ? $"{result - 1}" : $" {result} ";

        }
    }
}
