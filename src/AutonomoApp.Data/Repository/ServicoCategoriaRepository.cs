using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Data.Repository;

public class ServicoCategoriaRepository : Repository<Servico>
{
    public ServicoCategoriaRepository(AutonomoAppContext db) : base(db) { }

    public async Task<List<ServicoCategoria>> ObterTodosServicos()
    {
        return await Db.ServicoCategoria
            // .Include(x => x.ServicosServico)
             .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<Servico> ObterServicoPorUsuario(Guid id)
    {
        return await Db.Servico
            // .Include(x => x.ServicosServico)
            .AsNoTracking()
            .Where(servico => servico.Id == id)
            .FirstOrDefaultAsync();
    }
}