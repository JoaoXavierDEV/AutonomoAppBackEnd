using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.Brazil;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;

namespace AutonomoApp.Data.Repository.FakeRepository
{
    public static class DataBaseFake
    {
        public static List<PessoaFisica> GetPessoaFisica()
        {
            var lista = new List<PessoaFisica>();

            var enderecoFake = new Faker<Endereco>("pt_BR")
                    .RuleFor(x => x.Logradouro, y => y.Address.StreetName())
                    .RuleFor(x => x.Cep, y => y.Address.ZipCode("#####-###"))
                    .RuleFor(x => x.Cidade, y => y.Address.City())
                    .RuleFor(x => x.Bairro, y => y.Address.County())
                    .RuleFor(x => x.Estado, y => y.Address.State())
                    .RuleFor(x => x.Complemento, y => y.Lorem.Sentence(5))
                    .RuleFor(x => x.Numero, y => y.Address.BuildingNumber());

            var faker = new Faker<PessoaFisica>("pt_BR");
            for (int i = 0; i < 100; i++)
            {
                lista.Add(faker
                  .RuleFor(x => x.Nome, y => y.Name.FullName())
                  .RuleFor(x => x.Documento, y => y.Person.Cpf())
                  .RuleFor(x => x.Nascimento, y => y.Date.Past(40, new DateTime(2005, 01, 01))) // escolhe data minima e o número de anos pra reduzir//.RuleFor(x => x.Endereco, enderecoFake)
                  .RuleFor(x => x.TipoDocumento, TipoDocumentoEnum.PessoaFisica)
                  .RuleFor(x => x.Endereco, enderecoFake));
            }

            var servico = new Faker<Servico>("pt_BR")
            .RuleFor(x => x.DataPublicada, y => y.Date.Past())
            //.RuleFor(x => x.Prestador, clienteFake)
            .RuleFor(x => x.Nome, y => y.Name.JobType())
            .RuleFor(x => x.Descricao, y => y.Name.JobDescriptor())
            .RuleFor(x => x.Valor, y => y.Finance.Amount(100, 1000, 2))
            .RuleFor(x => x.Desconto, y => Math.Round(y.Random.Decimal(01, 10), 0))
            .RuleFor(x => x.TemDesconto, y => y.Random.Bool())
            .RuleFor(x => x.AnuncioAtivo, y => y.Random.Bool());

            var ran = new Random(2);
            foreach (var item in lista)
            {
                int numeroAleatorio = ran.Next(2, 20);
                if ((numeroAleatorio % 2) == 0)
                {
                    item.AddServicoHistoricoPedidos(new ServicoSolicitado
                    {
                        Servico = servico,
                        DataConclusaoEstimada = DateTime.Now.AddDays(ran.Next(2, 50)),
                    });

                }
            }


            return lista;
        }

        public static List<PessoaJuridica> GetPessoaJuridica()
        {
            List<PessoaJuridica> lista = new List<PessoaJuridica>();

            var enderecoFake = new Faker<Endereco>("pt_BR")
                    .RuleFor(x => x.Logradouro, y => y.Address.StreetName())
                    .RuleFor(x => x.Cep, y => y.Address.ZipCode("#####-###"))
                    .RuleFor(x => x.Cidade, y => y.Address.City())
                    .RuleFor(x => x.Bairro, y => y.Address.County())
                    .RuleFor(x => x.Estado, y => y.Address.State())
                    .RuleFor(x => x.Complemento, y => y.Lorem.Sentence(5))
                    .RuleFor(x => x.Numero, y => y.Address.BuildingNumber());

            var faker = new Faker<PessoaJuridica>("pt_BR");

            for (int i = 0; i < 100; i++)
                 lista.Add(faker
                      .RuleFor(x => x.Nome, y => y.Name.FullName())
                      .RuleFor(x => x.Documento, y => y.Company.Cnpj())
                      .RuleFor(x => x.NomeEmpresa, y => y.Company.CompanyName()) // escolhe data minima e o número de anos pra reduzir//.RuleFor(x => x.Endereco, enderecoFake)
                      .RuleFor(x => x.TipoDocumento, TipoDocumentoEnum.PessoaJuridica)
                      .RuleFor(x => x.Endereco, enderecoFake));


            var servico = new Faker<Servico>("pt_BR")
                        .RuleFor(x => x.DataPublicada, y => y.Date.Past())
                        //.RuleFor(x => x.Prestador, clienteFake)
                        .RuleFor(x => x.Nome, y => y.Name.JobType())
                        .RuleFor(x => x.Descricao, y => y.Name.JobDescriptor())
                        .RuleFor(x => x.Valor, y => y.Finance.Amount(100, 1000, 2))
                        .RuleFor(x => x.Desconto, y => Math.Round(y.Random.Decimal(01, 10), 0))
                        .RuleFor(x => x.TemDesconto, y => y.Random.Bool())
                        .RuleFor(x => x.AnuncioAtivo, y => y.Random.Bool());

            var ran = new Random(2);
            foreach (var item in lista)
            {
                int numeroAleatorio = ran.Next(2, 20);
                if ((numeroAleatorio % 2) == 0)
                {
                    item.AddServicoHistoricoPedidos(new ServicoSolicitado
                    {
                        Servico = servico,
                        DataConclusaoEstimada = DateTime.Now.AddDays(ran.Next(2, 50)),
                    });

                }
            }

            return lista;
        }

        public static List<Categoria> GetCategorias()
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
                } };

        }
    }
}
