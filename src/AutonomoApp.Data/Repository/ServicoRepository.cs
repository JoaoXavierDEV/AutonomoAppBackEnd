using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Data.Repository;

public class ServicoRepository : Repository<Servico>, IServicoRepository
{
    public ServicoRepository(AutonomoAppContext db) : base(db) { }

    public async Task<List<Servico>> ObterTodosServicos()
    {
        return await Db.Servico
             .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Servico> ObterServicoPorUsuario(Guid id)
    {
        return await Db.Servico
            .AsNoTracking()
            .Include(x => x.ClientePrestador)
            .Where(servico => servico.Id == id)
            .FirstOrDefaultAsync();
    }


    public async Task CadastrarServico(ServicoDTO servicoDto)
    {
        var servico = servicoDto.ToModel();

        var categoriaId = servicoDto.Categoria;
        Db.Entry(servico).Property("CategoriaId").CurrentValue = categoriaId;

        var pessoaId = servicoDto.Prestador;
        Db.Entry(servico).Property("ClientePrestadorId").CurrentValue = pessoaId;

        var subCategoriaId = servicoDto.Subcategoria;
        Db.Entry(servico).Property("SubcategoriaId").CurrentValue = subCategoriaId;

        await Adicionar(servico);
    }
    //public override async Task Adicionar(Servico servico)
    //{
    //    await base.Adicionar(servico);
    //}
}