using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Data.Mappings;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.ConsoleApp

{
    public class InserirDados
    {
        public void BuildEntity()
        {
            //ResetarDb();
            //CarregarDadosCategorias();
            //CarregarDadosPessoa();
            //CarregarServico();
            GetServico();
        }

        public void ResetarDb()
        {
            AutonomoAppContext db = new AutonomoAppContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public void CarregarDadosCategorias()
        {
            AutonomoAppContext db = new AutonomoAppContext();
            db.Categorias.AddRange(
                new Categoria()
                {
                    Id = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    CatEnumId = (int)CategoriaEnum.Tecnologia,
                    Nome = CategoriaEnum.Tecnologia.GetEnumDescription(),
                    Descricao = "Serviços de TI",
                    Subcategorias = new List<Subcategoria>{
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
                    Subcategorias = new EditableList<Subcategoria>()
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
            );

            db.SaveChanges();
            db.ChangeTracker.Clear();
        }

        public void CarregarDadosPessoa()
        {
            AutonomoAppContext db = new AutonomoAppContext();
            db.PessoaFisica.AddRange(new PessoaFisica()
            {
                Nome = "João Fernando",
                Documento = "11122233345",
                Nascimento = new DateTime(1995, 01, 31),
                TipoDocumentoEnum = TipoDocumentoEnum.PessoaFisica,
                HistoricoDePedidos =  new List<ServicoSolicitacao>(){ new ServicoSolicitacao()
                {
                    DataConclusaoEstimada = new DateTime(2022,12,12),
                    ServicoSolicitado = new Servico()
                    {
                        Nome = "Desenvolver app",
                        Descricao = "App de psicologia",
                        Valor = 8000m,
                        //Categoria = new List<Categoria>()
                        //{
                        //    new Categoria()
                        //    {
                        //        Nome = "Testeeee",
                        //        SubCatEnumId = 99,
                        //        Descricao = "hueteste",
                        //        Subcategorias = new List<Subcategoria>()
                        //        {
                        //            new Subcategoria()
                        //            {
                        //                Nome = "SubTeste",
                        //                SubCatEnumId = 88,
                        //                Descricao = "hue sub teste"
                        //            }
                        //        }
                        //    }
                        //}

                    }
                }

                },
            });

            db.SaveChanges();
            db.ChangeTracker.Clear();

        }

        public void CarregarServico()
        {
            AutonomoAppContext db = new AutonomoAppContext();

            db.Servico.AddRange(new Servico()
            {
                Cliente = new PessoaFisica()
                {
                    Nome = "Jaum",
                    Documento = "14494943746",
                    Nascimento = new DateTime(1995, 01, 31),
                    TipoDocumentoEnum = TipoDocumentoEnum.PessoaFisica
                },
                Nome = "Desenvolver app",
                Descricao = "App de psicologia",
                Valor = 8000m,
                CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                SubcategoriaId = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                ServicoCategoria = new List<ServicoCategoria>(){},
                //Categoria =  new Categoria(),

                Tags = new List<string>() { "aspnet", "microsoft" },

            });

            db.SaveChanges();
            db.ChangeTracker.Clear();
           }

        public void GetServico()
        {
            using var db = new AutonomoAppContext();

            var servicoUsuario = db.Servico
                .Include(x => x.Cliente)
                //.Include(x => x.SubCategoria)
                .Include(x => x.ServicoCategoria)
                .Where(x => x.Cliente.Documento == "14494943746")
                //.Select(p => p.Subcategorias.Where( c => c.SubCatEnumId == (int)Tecnologia.DevenvolvimetoBackEnd))
                .Select(x => x)
                .AsNoTracking()
                .First();

            //db.ChangeTracker.Clear();
            var servicoAll = db.Servico
                .Include(x => x.Cliente)
                .Include(x => x.ServicoCategoria)
                .ToList();

            var categoriasSubAll = db.Categorias
                .Include(c => c.Subcategorias)
                .ToList();

            var categoriasAll = db.Categorias
                .ToList();
            // refatorar nome de variaveis
            Console.ReadKey();
        }
    }
}