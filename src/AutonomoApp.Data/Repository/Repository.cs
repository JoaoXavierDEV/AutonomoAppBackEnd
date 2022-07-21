using System.Linq.Expressions;
using AutonomoApp.Business.Interfaces.IRepository;
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
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public IQueryable<T> Consultar()
    {
        return DbSet;
    }

    public async Task Adicionar(T entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public async Task<T> ObterPorId(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<List<T>> ObterTodos()
    {
        return await DbSet.ToListAsync();
    }

    public async Task Atualizar(T entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public async Task Remover(Guid id)
    {
        DbSet.Remove(new T { Id = id });
        await SaveChanges();
    }


    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }
    public void Dispose()
    {
        Db?.Dispose();
    }
}