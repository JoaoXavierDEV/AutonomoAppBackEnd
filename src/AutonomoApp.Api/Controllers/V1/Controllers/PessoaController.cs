using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Controllers.V1.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/Pessoas")]
[Produces("application/json")]
public class PessoaController : MainController
{
    private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
    private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

    public PessoaController(
            IPessoaFisicaRepository pessoaFisicaRepository,
            IPessoaJuridicaRepository pessoaJuridicaRepository
        )
    {
        _pessoaFisicaRepository = pessoaFisicaRepository;
        _pessoaJuridicaRepository = pessoaJuridicaRepository;
    }
    // TODO: arrumar as controller 
    // TODO: Random já foi resolvdo
    [HttpGet("e")]
    public Task<List<PessoaJuridica>> ObterListaPessoaJuridica(){
        return _pessoaJuridicaRepository.ObterTodos();
    }

}
