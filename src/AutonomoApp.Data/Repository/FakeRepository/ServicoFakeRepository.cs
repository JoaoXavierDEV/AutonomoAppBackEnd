using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Data.Repository.FakeRepository
{
    public class ServicoFakeRepository : RepositoryFake<Servico>, IServicoRepository
    {
        public Task<Servico> ObterServicoPorUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Servico>> ObterTodosServicos()
        {
            throw new NotImplementedException();
        }

        public override Task<List<Servico>> ObterTodos()
        {
            Func<List<Servico>> dados = () =>
            {
                var lista = new List<Servico>();

                var enderecoFake = new Faker<Endereco>("pt_BR")
                    .RuleFor(x => x.Logradouro, y => y.Address.StreetName())
                    .RuleFor(x => x.Cep, y => y.Address.ZipCode())
                    .RuleFor(x => x.Cidade, y => y.Address.City())
                    .RuleFor(x => x.Bairro, y => y.Address.County())
                    .RuleFor(x => x.Estado, y => y.Address.State())
                    .RuleFor(x => x.Complemento, y => y.Lorem.Sentence(5))
                    .RuleFor(x => x.Numero, y => y.Address.BuildingNumber());

                var clienteFake = new Faker<PessoaFisica>("pt_BR")
                    .RuleFor(x => x.Nome, y => y.Name.FullName())
                    .RuleFor(x => x.Documento, y => y.Person.Cpf())
                    .RuleFor(x => x.Endereco, enderecoFake)
                    .RuleFor(x => x.TipoDocumento, y => (TipoDocumentoEnum)y.Random.Int(1, 2));

                for (int i = 0; i < 2; i++)
                {
                    lista.Add(
                    _faker
                        .RuleFor(x => x.DataPublicada, y => y.Date.Past())
                        .RuleFor(x => x.Prestador, clienteFake)
                        .RuleFor(x => x.Nome, y => y.Name.JobType())
                        .RuleFor(x => x.Descricao, y => y.Name.JobDescriptor())
                        .RuleFor(x => x.Valor, y => y.Finance.Amount(100, 1000, 2))
                        .RuleFor(x => x.Desconto, y => y.Random.Decimal())
                        .RuleFor(x => x.TemDesconto, y => y.Random.Bool())
                        .RuleFor(x => x.AnuncioAtivo, y => y.Random.Bool())
                        );
                }
                return lista;
            };
            var task = new Task<List<Servico>>(dados);
            task.Start();
            return task;
        }

        
        public override IQueryable<Servico> Consultar() 
        {
            //T item = new();
            var clienteFake2 = new Faker("pt_BR");
            var lista = new List<Servico>();
            
            var enderecoFake = new Faker<Endereco>("pt_BR")
                .RuleFor(x => x.Logradouro, y => y.Address.StreetName())
                .RuleFor(x => x.Cep, y => y.Address.ZipCode())
                .RuleFor(x => x.Cidade, y => y.Address.City())
                .RuleFor(x => x.Bairro, y => y.Address.County())
                .RuleFor(x => x.Estado, y => y.Address.State())
                .RuleFor(x => x.Complemento, y => y.Lorem.Sentence(5))
                .RuleFor(x => x.Numero, y => y.Address.BuildingNumber());

            var clienteFake = new Faker<PessoaFisica>("pt_BR")
                .RuleFor(x => x.Nome, y => y.Name.FullName())
                .RuleFor(x => x.Documento, y => y.Person.Cpf())
                .RuleFor(x => x.Nascimento, y => y.Date.Past(35,new DateTime(1967,01,31))) // escolhe data minima e o número de anos pra reduzir
                .RuleFor(x => x.Endereco, enderecoFake)
                .RuleFor(x => x.TipoDocumento, y => y.Random.Enum<TipoDocumentoEnum>());


            for (int i = 0; i < 10000; i++)
            {
                lista.Add(
                _faker
                    .RuleFor(x => x.DataPublicada, y => y.Date.Past())
                    .RuleFor(x => x.Prestador, clienteFake)
                    .RuleFor(x => x.Nome, y => y.Name.JobType())
                    .RuleFor(x => x.Descricao, y => y.Name.JobDescriptor())
                    .RuleFor(x => x.Valor, y => y.Finance.Amount(100, 1000, 2))
                    .RuleFor(x => x.Desconto, y => Math.Round(y.Random.Decimal(01,90),0))
                    .RuleFor(x => x.TemDesconto, y => y.Random.Bool())
                    .RuleFor(x => x.AnuncioAtivo, y => y.Random.Bool())
                    );
            }

            return lista.AsQueryable();
        }

        public void VincularCategoria(Servico servico, Guid categoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
