using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Data.Context;
using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Data.Repository.FakeRepository;

public class PessoaJuridicaFakeRepository : RepositoryFake<PessoaJuridica>, IPessoaJuridicaRepository
{
    public override Task<List<PessoaJuridica>> ObterTodos()
    {
        Func<List<PessoaJuridica>> dados = () =>
        {
            var enderecoFake = new Faker<Endereco>("pt_BR")
                    .RuleFor(x => x.Logradouro, y => y.Address.StreetName())
                    .RuleFor(x => x.Cep, y => y.Address.ZipCode("#####-###"))
                    .RuleFor(x => x.Cidade, y => y.Address.City())
                    .RuleFor(x => x.Bairro, y => y.Address.County())
                    .RuleFor(x => x.Estado, y => y.Address.State())
                    .RuleFor(x => x.Complemento, y => y.Lorem.Sentence(5))
                    .RuleFor(x => x.Numero, y => y.Address.BuildingNumber());

            var lista = new List<PessoaJuridica>();

            for (int i = 0; i < 100; i++)
                lista.Add(_faker
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
                int numeroAleatorio = ran.Next(2,20);
                if ( (numeroAleatorio % 2) == 0){
                    item.AddServicoHistoricoPedidos(new ServicoSolicitado
                    {
                        Servico = servico,
                        DataConclusaoEstimada = DateTime.Now.AddDays(ran.Next(2,50)),                        
                    });

                }
            }

            return lista;
        };

        var task = new Task<List<PessoaJuridica>>(dados);
        task.Start();

        return task;
    }
}
