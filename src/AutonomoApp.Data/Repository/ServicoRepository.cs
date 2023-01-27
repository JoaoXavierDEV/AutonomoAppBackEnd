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

    public async void VincularCategoria(Servico servico, Guid categoriaId)
    {
        Db.Entry(servico).Property("CategoriaId").CurrentValue = categoriaId;
        await Atualizar(servico);
    }
}