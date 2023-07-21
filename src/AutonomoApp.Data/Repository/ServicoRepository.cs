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


    public async Task CadastrarServico(Servico servico)
    {
        try
        {
            //var categoriaId = servico.Categoria.Id;
            //servico.Categoria = null;
            //Db.Entry(servico).Property("CategoriaId").CurrentValue = categoriaId;

            //var pessoaId = servico.ClientePrestador.Id;
            //servico.ClientePrestador = null;
            //Db.Entry(servico).Property("ClientePrestadorId").CurrentValue = pessoaId;

            //var subCategoriaId = servico.Subcategoria.Id;
            //servico.Subcategoria = null;
            //Db.Entry(servico).Property("SubcategoriaId").CurrentValue = subCategoriaId;

            await Adicionar(servico);
        }
        catch (Exception)
        {

            throw;
        }
    }
    //public override async Task Adicionar(Servico servico)
    //{
    //    await base.Adicionar(servico);
    //}
}