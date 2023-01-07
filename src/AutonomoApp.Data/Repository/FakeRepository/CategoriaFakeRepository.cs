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


    //public CategoriaFakeRepository( Faker<Categoria> faker) : base(faker)
    //{

    //}

    public Task<List<Categoria>> ObterTodasCategorias()
    {
        var result = ObterTodasCategorias();
        Func<List<Categoria>> RetornaSubcategorias = () =>
        {
            return result.Result.Select(x => x).ToList();
        };
        var task = new Task<List<Categoria>>(RetornaSubcategorias);
        task.Start();
        return task;
    }

    public Task<List<Categoria>> ObterTodasCategoriasESubcategorias()
    {
        Func<List<Categoria>> RetornaCategorias = () =>
        {
            return new List<Categoria>()
            {
                new Categoria()
            {
                Id = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                CatEnumId = (int)CategoriaEnum.Tecnologia,
                Nome = CategoriaEnum.Tecnologia.GetEnumDescription(),
                Descricao = "Serviços de TI",
                Subcategorias = new List<Subcategoria> {
                    new Subcategoria()
                    {
                        SubCatEnumId = (int)Tecnologia.DevenvolvimetoFrontEnd,
                        Nome = Tecnologia.DevenvolvimetoFrontEnd.GetEnumDescription(),
                    },
                    new Subcategoria()
                    {
                        Id = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                        SubCatEnumId = (int)Tecnologia.DevenvolvimetoBackEnd,
                        Nome = Tecnologia.DevenvolvimetoBackEnd.GetEnumDescription(),
                    },
                    new Subcategoria()
                    {
                        SubCatEnumId = (int)Tecnologia.Infra,
                        Nome = Tecnologia.Infra.GetEnumDescription(),
                    },
                    new Subcategoria()
                    {
                        SubCatEnumId = (int)Tecnologia.DevOps,
                        Nome = Tecnologia.DevOps.GetEnumDescription(),
                    }
                }
            },
                new Categoria()
            {
                CatEnumId = (int)CategoriaEnum.ServicosGerais,
                Nome = CategoriaEnum.ServicosGerais.GetEnumDescription(),
                Descricao = "Serviços de Limpezae afins",
                Subcategorias = new List<Subcategoria>()
                {
                    new Subcategoria()
                    {
                        SubCatEnumId = (int)ServicosGerais.Varrer,
                        Nome = ServicosGerais.Varrer.GetEnumDescription()
                    },
                    new Subcategoria()
                    {
                        SubCatEnumId = (int)ServicosGerais.LavarLouca,
                        Nome = ServicosGerais.LavarLouca.GetEnumDescription()
                    },
                    new Subcategoria()
                    {
                        SubCatEnumId = (int)ServicosGerais.Limpeza,
                        Nome = ServicosGerais.Limpeza.GetEnumDescription()
                    },
                }
            },
                new Categoria()
                {
                    CatEnumId = (int)CategoriaEnum.Lanches,
                    Nome = CategoriaEnum.Lanches.GetEnumDescription(),
                    Descricao = "Peça seu lanche",
                    Subcategorias = new List<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            SubCatEnumId = (int)Lanches.Doces,
                            Nome = Lanches.Doces.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            SubCatEnumId = (int)Lanches.Pizza,
                            Nome = Lanches.Pizza.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            SubCatEnumId = (int)Lanches.Restaurantes,
                            Nome = Lanches.Restaurantes.GetEnumDescription()
                        },
                    }
                }
            };
        };
        var task = new Task<List<Categoria>>(RetornaCategorias);
        task.Start();

        return task;         
    }
    public override Task Adicionar(Categoria entity)
    {
        return base.Adicionar(entity);
    }

}
