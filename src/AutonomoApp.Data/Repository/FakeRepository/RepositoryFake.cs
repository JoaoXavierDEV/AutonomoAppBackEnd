using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Data.Repository.FakeRepository
{
    public abstract class RepositoryFake<T> : IRepository<T> where T : EntityBase, new()
    {
        public Task Adicionar(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Buscar(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TAbela> Consultar<TAbela>() where TAbela : EntityBase
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<T> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
