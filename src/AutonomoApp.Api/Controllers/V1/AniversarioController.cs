﻿using AutonomoApp.Framework.Controllers;
using AutonomoApp.Framework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace AutonomoApp.WebApi.Controllers.V1;

/// <summary>Class <c>AniversarioController</c> modelo de documentação.</summary>
/// <remarks>Apenas testes classe</remarks>
[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/aniversario")]
[Produces("application/json")]
public class AniversarioController : MainController
{
    public AniversarioController(INotificador notificador, IUser appUser) : base(notificador, appUser)
    {
    }

    /// <summary>
    /// Informe o ano de nascimento
    /// <example><br></br>Exemplo:
    /// Retorna sua <c>idade</c>
    /// </example>
    /// </summary>
    /// <remarks>Apenas testes método
    /// <code>
    /// AAAA-MM-DD
    /// </code>
    /// </remarks>
    /// <param name="nascimento">Data de nascimento completa</param>
    /// <returns>Idade do usuario = int</returns>
    /// <response code="200"> Mensagem 200 </response>
    /// <response code="400"> Mensagem de erro 400 </response>
    /// <response code="404"> Mensagem de erro 404 não encontrado </response>
    [HttpPost("idade/{nascimento:datetime}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    private ActionResult<string> ObterIdade(DateTime nascimento)
    {
        var result = DateTime.Now.Year - nascimento.Year;

        return DateTime.Now.DayOfYear < nascimento.DayOfYear ? $"{result - 1}" : $" {result} ";

    }
}

