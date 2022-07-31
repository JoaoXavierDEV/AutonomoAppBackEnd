﻿using AutonomoApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Api.V2.Controllers
{
    [ApiVersion("2.1", Deprecated = false)]
    [Route("api/v{version:apiVersion}/aniversario")]
    [Produces("application/json")]
    public class AniversarioController : MainController
    {
        /// <summary>
        /// Função pra retornar a idade do usuario
        /// </summary>
        /// <param name="nascimento">Data de nascimento completa</param>
        /// <returns>Idade do usuario = int</returns>
        [HttpGet("idade/{nascimento:datetime}")]
        public ActionResult<string> ObterIdade(DateTime nascimento)
        {
            var result = DateTime.Now.Year - nascimento.Year;

            return DateTime.Now.DayOfYear < nascimento.DayOfYear ? $"{result - 1}" : $" {result} ";

        }
    }
}
