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
            // .Include(x => x.ServicosServico)
             .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<Servico> ObterServicoPorUsuario(Guid id)
    {
        return await Db.Servico
            // .Include(x => x.ServicosServico)
            .AsNoTracking()
            .Include(x => x.Prestador)
            .Where(servico => servico.Id == id)
            .FirstOrDefaultAsync();
    }
}