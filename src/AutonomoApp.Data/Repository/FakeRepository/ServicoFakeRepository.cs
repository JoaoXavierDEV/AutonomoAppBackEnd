using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using System;
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
                for (int i = 0; i < 10; i++)
                {
                    lista.Add(_faker
                        .RuleFor(x => x.DataPublicada , y => y.Date.Future())); ;
                }
                return lista;
            };
            var task = new Task<List<Servico>>(dados);
            task.Start();
            return task;
        }
    }
}
