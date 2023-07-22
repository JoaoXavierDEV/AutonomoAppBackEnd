using AutoMapper;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Repository;
using AutonomoApp.WebApi.ViewModels;
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

    [HttpGet("Obter/{id:guid}")]
    public async Task<Servico> ObterServico(Guid id)
    {
        return await _servicoRepository.ObterPorId(id);
    }

    [HttpPut("AtualizarServico/{id:guid}")]
    public void AtualizarServico(Guid id, ServicoViewModel servico)
    {
        _servicoRepository.Atualizar(_mapper.Map<Servico>(servico));
    }

    [HttpPost("CadastrarServico")]
    public async Task<ActionResult<ServicoViewModel>> CadastrarServico(ServicoViewModel servico)
    {
        try
        {
            servico.Tags = RemoverTagsInvalidas(servico.Tags);

            var servicoMap = _mapper.Map<Servico>(servico);

            await _servicoService.ValidarServico(_mapper.Map<Servico>(servico));

            return CustomResponse(servico);
        }
        catch (AutoMapperMappingException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpDelete("Deletar/{id:guid}")]
    public async Task<ActionResult<Servico>> Deletar(Guid id)
    {
        try
        {
            var servico = await ObterServico(id);
            if (servico == null) return NotFound(new { erru = true, dado = "Não encontrado: " + id });
            await _servicoRepository.Remover(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erru = true, erros = ex.InnerException?.Message ?? ex.Message });
        }
        return Ok(new { erru = false, dado = id });
    }

    private static List<String> RemoverTagsInvalidas(IEnumerable<string> lista)
    => lista.Where(x => x != "" && x != null && x != " ").ToList();
    
}

