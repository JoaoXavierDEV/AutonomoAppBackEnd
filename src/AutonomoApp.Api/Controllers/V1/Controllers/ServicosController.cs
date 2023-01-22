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
    public async Task<List<Servico>> ObterTodosServicos(
        // [FromServices] ICategoriaRepository catResolve // 
        )
    {
        var idServico = Guid.Parse("062932e5-7aa2-4cf0-8bea-a406233fdcf0");

        var tt = await _servicoRepository.ObterTodos();

        // dto2 = await _servicoService.ObterServicoDTO(idServico);
        var consultar = _servicoRepository
            .Consultar<Categoria>()
            .Where(x => x.CatEnumId == 1)
            .FirstOrDefault();

        var yy = _servicoRepository.Consultar().Where(x => x.Desconto < 50m).ToList();
        var datanice = _servicoRepository
            .Consultar<PessoaFisica>()
            .Where(x => x.Nascimento < new DateTime(1995,01,31))
            .ToList();

        var cat = new CategoriaFakeRepository();
        var ter = cat.Consultar<Servico>();

        var dto = new ServicoDTO
        {
            
        };

        return tt;
    }
}

