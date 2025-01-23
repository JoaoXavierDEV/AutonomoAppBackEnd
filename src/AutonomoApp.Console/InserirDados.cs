using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Data.Context;
using AutonomoApp.Data.Mappings.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AutonomoApp.Framework.ExtensionMethods;

namespace AutonomoApp.ConsoleApp

{
    public class InserirDados
    {
        public Endereco Endereco { get; set; } = new Endereco
        {
            Bairro = "Califórnia",
            Cep = "26220330",
            Cidade = "Nova Iguaçu",
            Complemento = "Ali bem perto",
            Numero = "263",
            Logradouro = "Rua perto do outro lado na volta antes do retorno",
            Estado = "Rio de Janeiro",
        };

        public void BuildEntity()
        {
            ResetarDb();
            // CarregarDadosCategorias();
            //CarregarUsuarioIdentity();
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
        public static void ResetarAutonomoApp()
        {
            AutonomoAppContext db = new();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        public static void ResetarIdentity()
        {
            //ApplicationDbContext db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            //db.Database.EnsureDeleted();
            //db.Database.Migrate();
            //db.Database.GetAppliedMigrations();
            // TODO arrumar um jeito de criar migrations e aplicar
        }


        public void CarregarDadosCategorias()
        {
            AutonomoAppContext db = new();
            db.Categorias.AddRange(
                new Categoria()
                {
                    Id = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
                    CategoriaEnum = CategoriaEnum.Tecnologia,
                    Nome = CategoriaEnum.Tecnologia.GetEnumDescription(),
                    Descricao = "Serviços de TI",
                    Subcategorias = new List<Subcategoria>{
                        new Subcategoria()
                        {
                            Id = Guid.Parse("d06d1ab2-254b-47bf-b93a-07918ee88e30"),
                            SubCategoriaEnum = (int)Tecnologia.DevenvolvimetoFrontEnd,
                            Nome = Tecnologia.DevenvolvimetoFrontEnd.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                            SubCategoriaEnum = (int)Tecnologia.DevenvolvimetoBackEnd,
                            Nome = Tecnologia.DevenvolvimetoBackEnd.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("f8316134-c75b-44a1-970b-0967b9c894ad"),
                            SubCategoriaEnum = (int)Tecnologia.Infra,
                            Nome = Tecnologia.Infra.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("32df3d1d-24d7-4c72-abd1-5b7fd44aa4c4"),
                            SubCategoriaEnum = (int)Tecnologia.DevOps,
                            Nome = Tecnologia.DevOps.GetEnumDescription(),
                            Descricao = "Descrição"
                        }
                    }
                },
                new Categoria()
                {
                    Id = Guid.Parse("79f17f4a-95b9-4c90-8a6b-0857a247a6c5"),
                    CategoriaEnum = CategoriaEnum.ServicosGerais,
                    Nome = CategoriaEnum.ServicosGerais.GetEnumDescription(),
                    Descricao = "Serviços de Limpezae afins",
                    Subcategorias = new List<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            Id = Guid.Parse("d8eb10fc-6f02-4ed2-b44c-1a672e00c0db"),
                            SubCategoriaEnum = (int)ServicosGerais.Varrer,
                            Nome = ServicosGerais.Varrer.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("bf6436a4-5b26-4872-83e6-428a8dfc6dba"),
                            SubCategoriaEnum = (int)ServicosGerais.LavarLouca,
                            Nome = ServicosGerais.LavarLouca.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("9c7f8561-4181-4e44-b07d-e17108d53202"),
                            SubCategoriaEnum = (int)ServicosGerais.Limpeza,
                            Nome = ServicosGerais.Limpeza.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                    }
                },
                new Categoria()
                {
                    Id = Guid.Parse("6c629fe0-59e6-44d1-a4cb-509c8fb68a53"),
                    CategoriaEnum = CategoriaEnum.Lanches,
                    Nome = CategoriaEnum.Lanches.GetEnumDescription(),
                    Descricao = "Peça seu lanche",
                    Subcategorias = new List<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            Id = Guid.Parse("dfda8419-293d-4490-8062-28085ed297f9"),
                            SubCategoriaEnum = (int)Lanches.Doces,
                            Nome = Lanches.Doces.GetEnumDescription(),
                            Descricao = "Descrição"
                            
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("f0ca3298-c48d-4f67-a83d-50eba0e31d14"),
                            SubCategoriaEnum = (int)Lanches.Pizza,
                            Nome = Lanches.Pizza.GetEnumDescription(),
                            Descricao = "Descrição"
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("2837f8d3-18ea-4d44-a451-c825eed1bb48"),
                            SubCategoriaEnum = (int)Lanches.Restaurantes,
                            Nome = Lanches.Restaurantes.GetEnumDescription(),
                            Descricao = "Descrição"
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
            /*

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
            db.ChangeTracker.Clear();*/
        }

        public void CarregarUsuarioIdentity()
        {
            AutonomoAppContext db = new();

            var user = new UsuarioIdentity
            {
                UserName = "joaojfmx",
                Email = "joao_jfmx@outlook.com",
                EmailConfirmed = true,
                Pessoa =
                new Business.Models.PessoaFisica
                {
                    Nome = "João Fernando Moura Xavier",
                    Endereco = Endereco,
                    Nascimento = new DateTime(1995, 01, 31),
                    Documento = "24485264820",
                },
            };
            //db.UsuarioIdentity.Add(user);
            db.SaveChanges();
            db.ChangeTracker.Clear();

        }

        public void CarregarServico()
        {
            AutonomoAppContext db = new();

            var servico = new Servico()
            {
                //Id = Guid.Parse("062932E5-7AA2-4CF0-8BEA-A406233FDCF0"),
                Nome = "App de PetShop",
                Descricao = "Desenvolver aplicativo para Android em Flutter",
                Valor = 8500.99m,
                Tags = new List<string>() { "aspnet", "microsoft", "petshop", " ", "", " " },
            };

            db.Servico.AddRange(servico);

            var categoriaId = Guid.Parse("79f17f4a-95b9-4c90-8a6b-0857a247a6c5");
            db.Entry(servico).Property("CategoriaId").CurrentValue = categoriaId;
            
            var pessoaId = Guid.Parse("A79A1705-4292-4B34-B55A-C081B9E9E7AF");
            db.Entry(servico).Property("ClientePrestadorId").CurrentValue = pessoaId;

            var subCategoriaId = Guid.Parse("d8eb10fc-6f02-4ed2-b44c-1a672e00c0db");
            db.Entry(servico).Property("SubcategoriaId").CurrentValue = subCategoriaId;



            db.SaveChanges();
            db.ChangeTracker.Clear();
        }

        public static void ServicosTeste()
        {
            var ss = new Servico
            {
                Valor = 250.00m,
                Desconto = 8.0m,
                AplicaDesconto = true,
            };
            var result = ss.PrecoComDesconto;
            var precodesconto = ss.ValorDescontado;
            var valooor = ss.Valor;
            ss.Valor = 300.00m;
            var valooor2 = ss.Valor;
        }


    }
}