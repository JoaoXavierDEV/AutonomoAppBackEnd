using ASPNET.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.Api.V2.Controllers
{
    [ApiVersion("2.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/aniversario")]
    public class AniversarioController : MainController
    {
        [HttpGet("idade/{nascimento:datetime}")]
        public ActionResult<string> ObterIdade(DateTime nascimento)
        {
            var result = DateTime.Now.Year - nascimento.Year;

            return DateTime.Now.DayOfYear < nascimento.DayOfYear ? $"{result - 1}" : $" {result} ";

        }
    }
}
