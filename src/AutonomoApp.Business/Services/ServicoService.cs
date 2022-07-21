using System;
using System.Threading.Tasks;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.Services;

public class ServicoService : BaseService, IServicoService
{
    private readonly IServicoRepository _servicoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ServicoService(IServicoRepository servicoRepository, ICategoriaRepository categoriaRepository)
    {
        _servicoRepository = servicoRepository;
        _categoriaRepository = categoriaRepository;
    }


    public async Task<ServicoDTO> ObterServicoDTO(Guid id)
    {
        var ser = await _servicoRepository.ObterServicoPorUsuario(id);
        var idCat = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e");

        var cat = await _categoriaRepository.ObterPorId(idCat);
        var catdto = new CategoriaDto(cat);

        var tt = _servicoRepository.Consultar();

        var servicoDto = new ServicoDTO()
        {
            Cliente = ser.Cliente,
            Categoria = catdto,
            Descricao = ser.Descricao,
            Nome = ser.Nome,
            Valor = ser.Valor,
            Tags = ser.Tags,
            Subcategoria = new Subcategoria()
            {
                Nome = "testes"
            }

        };
        return servicoDto;
    }
}