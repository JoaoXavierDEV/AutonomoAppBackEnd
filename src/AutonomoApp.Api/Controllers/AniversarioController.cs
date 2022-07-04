using ASPNET.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.Api.Controllers
{
    [ApiController]
    public class AniversarioController : MainController
    {
        [HttpGet("idade/{nascimento:datetime}")]
        public ActionResult<string> ObterIdade(DateTime nascimento)
        {
            var result = DateTime.Now.Year - nascimento.Year;
            
             return DateTime.Now.DayOfYear < nascimento.DayOfYear ? $"{result - 1}" : $" {(result)} ";
            
        }
    }
}
