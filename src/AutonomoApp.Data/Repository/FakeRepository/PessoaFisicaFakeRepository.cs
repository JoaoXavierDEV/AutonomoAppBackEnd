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

public class PessoaFisicaFakeRepository : RepositoryFake<PessoaFisica>, IPessoaFisicaRepository
{
    public override Task<List<PessoaFisica>> ObterTodos()
    {
        Func<List<PessoaFisica>> dados = () =>
        {
            var enderecoFake = new Faker<Endereco>("pt_BR")
                    .RuleFor(x => x.Logradouro, y => y.Address.StreetName())
                    .RuleFor(x => x.Cep, y => y.Address.ZipCode("#####-###"))
                    .RuleFor(x => x.Cidade, y => y.Address.City())
                    .RuleFor(x => x.Bairro, y => y.Address.County())
                    .RuleFor(x => x.Estado, y => y.Address.State())
                    .RuleFor(x => x.Complemento, y => y.Lorem.Sentence(5))
                    .RuleFor(x => x.Numero, y => y.Address.BuildingNumber());

            var lista = new List<PessoaFisica>();

            for (int i = 0; i < 100; i++)
            {
                lista.Add(
                _faker
                  .RuleFor(x => x.Nome, y => y.Name.FullName())
                  .RuleFor(x => x.Documento, y => y.Person.Cpf())
                  .RuleFor(x => x.Nascimento, y => y.Date.Past(40, new DateTime(2005, 01, 01))) // escolhe data minima e o número de anos pra reduzir//.RuleFor(x => x.Endereco, enderecoFake)
                  .RuleFor(x => x.TipoDocumento, TipoDocumentoEnum.PessoaFisica)
                  .RuleFor(x => x.Endereco, enderecoFake)
                    );
            }

            return lista;
        };

        var task = new Task<List<PessoaFisica>>(dados);
        task.Start();

        return task;
    }
}
