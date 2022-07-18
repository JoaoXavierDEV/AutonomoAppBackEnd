using System.Linq.Expressions;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Data.Repository;

public abstract class Repository<T> : IRepository<T> where T : EntityBase, new()
{
    protected readonly AutonomoAppContext Db;
    protected readonly DbSet<T> DbSet;

    protected Repository(AutonomoAppContext db)
    {
        Db = db;
        DbSet = db.Set<T>();
    }
    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task Adicionar(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<T> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public async Task Atualizar(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task Remover(Guid id)
    {
        throw new NotImplementedException();
    }


    public async Task<int> SaveChanges()
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}