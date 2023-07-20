using AutoMapper;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Mappings.Identity;
using AutonomoApp.Data.Repository;
using AutonomoApp.Data.Repository.FakeRepository;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Controllers.V1;

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
        var tt = await _servicoRepository.ObterTodos();
        return tt;
    }
    [HttpGet("AtualizarServico")]
    public void AtualizarServico(ServicoDTO servico)
    {
        _servicoService.ValidarServico(servico);
    }

    [HttpPost("CadastrarServico")]
    public async Task<ActionResult<Servico>> CadastrarServico(ServicoDTO servico)
    {
        try
        {
            // teste pra ver se o usuario funcionou // remover dps
            var tt2 = _servicoRepository.Consultar<UsuarioIdentity>()
                .First(x => x.Id == Guid.Parse("7da12a17-b738-4158-45df-08db88c53be4"));


            // TODO o historico que está dando erro, criar viewmodels
            var tt = servico.Tags.Where(x => x != "" && x != null && x != " ").ToList();


            // if (!ModelState.IsValid) throw new Exception();

            _servicoService.ValidarServico(servico);
            return CustomResponse(servico);
        }
        catch (Exception ex)
        {
            return CustomResponse(ex);
            throw;
        }
    }
}

