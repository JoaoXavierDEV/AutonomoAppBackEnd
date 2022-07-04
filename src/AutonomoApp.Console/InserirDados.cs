using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using AutonomoApp.Business.Extensions;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.ConsoleApp

{
    public class InserirDados
    {
        public AutonomoAppContext ResetarDB()
        {
            AutonomoAppContext db = new AutonomoAppContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            //db.Categorias.AsNoTracking();
            //if (db.Categorias.Any())
            //{
            //    throw new Exception("Já existe dados");
            //}
            CarregarDadosPessoa();
            CarregarDadosCategorias();

            return db;

        }
        public void CarregarDadosCategorias()
        {
            AutonomoAppContext db = new AutonomoAppContext();
            db.Categorias.AddRange(
                new Categoria()
                {
                    IdEnum = (int)CategoriaEnum.Tecnologia,
                    Nome = CategoriaEnum.Tecnologia.GetEnumDescription(),
                    Descricao = "Serviços de TI",
                    Subcategorias = new List<Subcategoria>{
                        new Subcategoria()
                        {
                            IdEnum = (int)Tecnologia.DevenvolvimetoFrontEnd,
                            Nome = Tecnologia.DevenvolvimetoFrontEnd.GetEnumDescription(),
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)Tecnologia.DevenvolvimetoBackEnd,
                            Nome = Tecnologia.DevenvolvimetoBackEnd.GetEnumDescription(),
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)Tecnologia.Infra,
                            Nome = Tecnologia.Infra.GetEnumDescription(),
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)Tecnologia.DevOps,
                            Nome = Tecnologia.DevOps.GetEnumDescription(),
                        }
                    }
                },
                new Categoria()
                {
                    IdEnum = (int)CategoriaEnum.ServicosGerais,
                    Nome = CategoriaEnum.ServicosGerais.GetEnumDescription(),
                    Descricao = "Serviços de Limpezae afins",
                    Subcategorias = new List<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            IdEnum = (int)ServicosGerais.Varrer,
                            Nome = ServicosGerais.Varrer.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)ServicosGerais.LavarLouca,
                            Nome = ServicosGerais.LavarLouca.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)ServicosGerais.Limpeza,
                            Nome = ServicosGerais.Limpeza.GetEnumDescription()
                        },
                    }
                },
                new Categoria()
                {
                    IdEnum = (int)CategoriaEnum.Lanches,
                    Nome = CategoriaEnum.Lanches.GetEnumDescription(),
                    Descricao = "Peça seu lanche",
                    Subcategorias = new EditableList<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            IdEnum = (int)Lanches.Doces,
                            Nome = Lanches.Doces.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)Lanches.Pizza,
                            Nome = Lanches.Pizza.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            IdEnum = (int)Lanches.Restaurantes,
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
                Documento = "14494943746",
                Nascimento = new DateTime(1995,01,31),
                TipoDocumentoEnum = TipoDocumentoEnum.PessoaFisica
            });
            db.SaveChanges();
            db.ChangeTracker.Clear();

        }
    }
}