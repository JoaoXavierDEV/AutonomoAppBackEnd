﻿using AutonomoApp.Business.Interfaces.IRepository;
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
    [HttpGet("ListaPessoasJuridica")]
    public Task<List<PessoaJuridica>> ObterListaPessoaJuridica(){
        return _pessoaJuridicaRepository.ObterTodos();
    }

    [HttpGet("ListaPessoasFisica")]
    public async Task<List<PessoaFisica>> ObterListaPessoaFisica(){
        var tt = _pessoaFisicaRepository.Consultar<PessoaFisica>().ToList();
        var result = await _pessoaFisicaRepository.ObterTodos();
        return await _pessoaFisicaRepository.ObterTodos();
    }
    
    [HttpPost("BuscarPessoasFisicaPorNome")]
    public List<PessoaFisica> BuscarPessoasFisicaPorNome(string nome){
        return _pessoaFisicaRepository.BuscarPorNome(nome);
    }

}
