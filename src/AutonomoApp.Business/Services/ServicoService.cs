using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Business.Services;

public class ServicoService : BaseService, IServicoService
{
    private readonly IServicoRepository _servicoRepository;

    public ServicoService(IServicoRepository servicoRepository,
        INotificador notificador) : base(notificador)
    {
        _servicoRepository = servicoRepository;
    }
    public List<Servico> ServicosPrestadosPorUsuario(Guid id)
    {
        return _servicoRepository.Consultar<Servico>()
            .Where(z => z.Id == id)
            .OrderByDescending(x => x.DataPublicada)
            .ToList();
    }

    public async Task<ServicoDTO> ObterServicoDTO(Guid id)
    {
        var ser = await _servicoRepository.ObterServicoPorUsuario(id);

        // categoria
        var idCat = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e");
        var querycat = _servicoRepository
            .Consultar<Categoria>()
            .FirstOrDefault(x => x.Id == idCat);
        var catdto = new CategoriaDto(querycat);

        // subcategoria
        var subcatID = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb");
        var subcat = _servicoRepository
            .Consultar<Subcategoria>()            
            .FirstOrDefault(x => x.Id == subcatID);
        var subCatDto = new SubCategoriaDto(subcat);

        var servicoDto = new ServicoDTO()
        {
            //Prestador = ser.ClientePrestador,
            Nome = ser.Nome,
            Descricao = ser.Descricao,
            Valor = ser.Valor,
            Tags = ser.Tags,
            //Categoria = catdto,
            //Subcategoria = subCatDto

        };
        return servicoDto;
    }

    public async void ValidarServico(ServicoDTO servico)
    {
        var query = _servicoRepository.Consultar<Servico>()
            .Where(x => x.ClientePrestador.Id == servico.Prestador && x.Nome == servico.Nome)
            .Count();

        if (query > 0) throw new Exception("Já existe um serviço cadastrado com esse nome!");

         await _servicoRepository.CadastrarServico(servico);    

    }

}