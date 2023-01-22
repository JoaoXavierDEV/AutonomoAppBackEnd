using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutonomoApp.Business.Extensions;
using Bogus;

namespace AutonomoApp.Data.Repository.FakeRepository;

public class CategoriaFakeRepository : RepositoryFake<Categoria>, ICategoriaRepository
{
    public Task<List<Categoria>> ObterTodasCategorias()
    {
        var result = Consultar<Categoria>().ToList();
        Func<List<Categoria>> RetornaSubcategorias = () =>
        {
            return result.Select(x => new Categoria
            {
                Descricao= x.Descricao,
                Nome= x.Nome,
                CatEnumId= x.CatEnumId,
                Id= x.Id,
            }).ToList();
        };
        var task = new Task<List<Categoria>>(RetornaSubcategorias);
        task.Start();
        return task;
    }

    public override Task Adicionar(Categoria entity)
    {
        return base.Adicionar(entity);
    }

    public Task<List<Categoria>> ObterTodasCategoriasESubcategorias()
    {
        return ObterTodasCategorias();
    }

    public Task AdicionarSubcategoria(Subcategoria subcategoria)
    {
        throw new NotImplementedException();
    }
}
