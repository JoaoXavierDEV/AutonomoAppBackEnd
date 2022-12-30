using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutonomoApp.ConsoleApp

{
    public class InserirDados
    {
        public void BuildEntity()
        {
            ResetarDb();
            CarregarDadosCategorias();
            //CarregarDadosPessoa();
            //CarregarServico();
            //RelacionamentosCateSubCat();
            //GetServico();
        }

        public static void ResetarDb()
        {
            AutonomoAppContext db = new();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public void CarregarDadosCategorias()
        {
            AutonomoAppContext db = new();
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
            );

            db.SaveChanges();
            db.ChangeTracker.Clear();
        }
        public void CarregarDadosCategoriasV2()
        {
            AutonomoAppContext db = new();


            db.Categorias.AddRange(
                new Categoria()
                {
                    Id = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    CatEnumId = (int)CategoriaEnum.Tecnologia,
                    Nome = CategoriaEnum.Tecnologia.GetEnumDescription(),
                    Descricao = "Serviços de TI",
                },
                new Categoria()
                {
                    Id = Guid.Parse("7FC9F7DC-7262-4869-B33D-C4A9645964E1"),
                    CatEnumId = (int)CategoriaEnum.ServicosGerais,
                    Nome = CategoriaEnum.ServicosGerais.GetEnumDescription(),
                    Descricao = "Serviços de Limpezae afins",
                },
                new Categoria()
                {
                    Id = Guid.Parse("1193CCC4-9B48-4875-8526-E1E1CCA27173"),
                    CatEnumId = (int)CategoriaEnum.Lanches,
                    Nome = CategoriaEnum.Lanches.GetEnumDescription(),
                    Descricao = "Peça seu lanche",
                }

            );
            db.Subcategorias.AddRange(
                new Subcategoria()
                {
                    CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    SubCatEnumId = (int)Tecnologia.DevenvolvimetoFrontEnd,
                    Nome = Tecnologia.DevenvolvimetoFrontEnd.GetEnumDescription(),
                },
                new Subcategoria()
                {
                    CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    Id = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                    SubCatEnumId = (int)Tecnologia.DevenvolvimetoBackEnd,
                    Nome = Tecnologia.DevenvolvimetoBackEnd.GetEnumDescription(),
                },
                new Subcategoria()
                {
                    CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    SubCatEnumId = (int)Tecnologia.Infra,
                    Nome = Tecnologia.Infra.GetEnumDescription(),
                },
                new Subcategoria()
                {
                    CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    SubCatEnumId = (int)Tecnologia.DevOps,
                    Nome = Tecnologia.DevOps.GetEnumDescription(),
                },
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
                }
                );
            db.SaveChanges();
            db.ChangeTracker.Clear();
        }

        public void CarregarDadosPessoa()
        {
            AutonomoAppContext db = new();
            db.PessoaFisica.AddRange(new PessoaFisica()
            {
                //Id = Guid.NewGuid(),
                Nome = "João Fernando",
                Documento = "11122233345",
                Endereco = new Endereco
                {
                    Cep = "26220330",
                    Cidade = "Nova iguaçu",
                    Numero = "263",
                    Bairro = "Aq",
                    Estado = "RJ",
                },
                Nascimento = new DateTime(1995, 01, 31),
                TipoDocumentoEnum = TipoDocumentoEnum.PessoaFisica,
                //HistoricoDePedidos = new List<ServicoSolicitacao>()
                //{
                //    new ServicoSolicitacao()
                //        {
                //            DataConclusaoEstimada = new DateTime(2022,12,12),
                //            ServicoSolicitado = new Servico()
                //            {
                //                Nome = "Desenvolver app",
                //                Descricao = "App de psicologia",
                //                Tags = new List<string>() { "aspnet", "microsoft" },
                //                Valor = 8000m,
                //                CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                //                SubcategoriaId = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                                
                //                //Categoria = new List<Categoria>()
                //                //{
                //                //    new Categoria()
                //                //    {
                //                //        Nome = "Testeeee",
                //                //        SubCatEnumId = 99,
                //                //        Descricao = "hueteste",
                //                //        Subcategorias = new List<Subcategoria>()
                //                //        {
                //                //            new Subcategoria()
                //                //            {
                //                //                Nome = "SubTeste",
                //                //                SubCatEnumId = 88,
                //                //                Descricao = "hue sub teste"
                //                //            }
                //                //        }
                //                //    }
                //                //}

                //            },
                   // }
               // }




            });

            db.SaveChanges();
            db.ChangeTracker.Clear();

        }

        public void CarregarServico()
        {
            AutonomoAppContext db = new();

            db.Servico.AddRange(new Servico()
            {
                Id = Guid.Parse("062932E5-7AA2-4CF0-8BEA-A406233FDCF0"),
                Cliente = new PessoaFisica()
                {
                    Nome = "Jaum",
                    Documento = "11122233300",
                    Nascimento = new DateTime(1995, 01, 31),
                    TipoDocumentoEnum = TipoDocumentoEnum.PessoaFisica
                },
                Nome = "Desenvolver app",
                Descricao = "App de psicologia",
                Valor = 8000m,
                CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                SubcategoriaId = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                //ServicoCategoria = new List<ServicoCategoria>() { },
                //Categoria =  new Categoria(),

                Tags = new List<string>() { "aspnet", "microsoft" },

            });

            db.SaveChanges();
            db.ChangeTracker.Clear();
        }

        public void RelacionamentosCateSubCat()
        {
            AutonomoAppContext db = new();

            db.ServicoCategoria.AddRange(
                new ServicoCategoria()
                {
                    ServicoId = Guid.Parse("062932E5-7AA2-4CF0-8BEA-A406233FDCF0"),
                    CategoriaId = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                });
            db.ServicoSubCategoria.AddRange(
                new ServicoSubCategoria()
                {
                    ServicoId = Guid.Parse("062932E5-7AA2-4CF0-8BEA-A406233FDCF0"),
                    SubCategoriaId = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb")
                });
            db.SaveChanges();
            db.ChangeTracker.Clear();
        }
        

    }
}