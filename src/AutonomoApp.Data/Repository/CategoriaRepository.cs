﻿using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Data.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AutonomoAppContext db) : base(db) { }

    public async Task<List<Categoria>> ObterTodasCategorias()
    {
        return await Db.Categorias
            //.Include(x => x.Subcategorias)
            .OrderBy(x=> x.CategoriaEnum)
            .ToListAsync();
    }

    public async Task<List<Categoria>> ObterTodasCategoriasESubcategorias()
    {
        return await Db.Categorias
            .Include(x => x.Subcategorias)
            .OrderBy(x=> x.CategoriaEnum)
            .ToListAsync();
    }

}