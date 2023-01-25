using AutoMapper;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Repository;
using AutonomoApp.Data.Repository.FakeRepository;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Controllers.V1.Controllers;

[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/Servicos")]
[Produces("application/json")]
public class ServicosController : MainController
{
    private readonly IServicoRepository _servicoRepository;
    private readonly IServicoService _servicoService;
    private readonly IMapper _mapper;

    public ServicosController(IServicoRepository servicoRepository,
        IServicoService servicoService, IMapper mapper,
         INotificador notificador, IUser user
        ) : base(notificador, user)
    {
        _servicoRepository = servicoRepository;
        _servicoService = servicoService;
        _mapper = mapper;
    }

    [HttpGet("ObterTodosServicos")]
    public async Task<List<Servico>> ObterTodosServicos()
    {
        var idServico = Guid.Parse("062932e5-7aa2-4cf0-8bea-a406233fdcf0");

        var idCategoria = Guid.Parse("ea220006-51b2-4993-8a6b-ba2b04d8be7e");

        var servico = new Servico()
        {
            Id = idServico,
        };

        _servicoService.VincularCategoriaAoServico(servico, idCategoria);

        var tt = await _servicoRepository.ObterTodos();

        var dto2 = await _servicoService.ObterServicoDTO(idServico);


        var dto = new ServicoDTO
        {
            
        };

        return tt;
    }
    [HttpGet("AtualizarServico")]
    public void AtualizarServico(Servico servico, Guid categoriaID)
    {
        _servicoService.VincularCategoriaAoServico(servico,categoriaID);
    }

    [HttpPost("CadastrarServico")]
    public async Task<Servico> CadastrarServico()
    {
        // if (!ModelState.IsValid) throw new Exception();

        await _servicoRepository.Adicionar(new Servico());
        return new Servico();
    }
}

