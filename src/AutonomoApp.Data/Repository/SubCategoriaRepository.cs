using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Data.Repository;

public class SubCategoriaRepository : Repository<Subcategoria>, ISubCategoriaRepository
{
    public SubCategoriaRepository(AutonomoAppContext db) : base(db) { }

    public async Task<List<Subcategoria>> ObterTodasSubCategorias()
    {
        return await Db.Subcategorias
            .OrderBy(x=> x.SubCategoriaEnum)
            .ToListAsync();
    }
}