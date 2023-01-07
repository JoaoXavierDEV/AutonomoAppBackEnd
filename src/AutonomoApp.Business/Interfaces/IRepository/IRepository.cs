using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.Interfaces.IRepository;

public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
{
    Task Adicionar(TEntity entity);
    IQueryable<TAbela> Consultar<TAbela>() where TAbela : EntityBase;
    IQueryable<TEntity> Consultar();
    Task<TEntity> ObterPorId(Guid id);
    Task<List<TEntity>> ObterTodos();
    Task Atualizar(TEntity entity);
    Task Remover(Guid id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
