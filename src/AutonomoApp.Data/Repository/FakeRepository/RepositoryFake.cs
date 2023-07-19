using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Data.Repository.FakeRepository;
public abstract class RepositoryFake<T> : IRepository<T> where T : EntityBase, new()
{
    protected Faker<T> _faker = new Faker<T>("pt_BR");

    protected RepositoryFake() { }

    #region CONSULTAR<T>
    public IQueryable<TAbela> Consultar<TAbela>() where TAbela : class
    {
        if (typeof(TAbela) == typeof(PessoaFisica))
            return (IQueryable<TAbela>)DataBaseFake.GetPessoaFisica().AsQueryable();

        if (typeof(TAbela) == typeof(PessoaJuridica))
            return (IQueryable<TAbela>)DataBaseFake.GetPessoaJuridica().AsQueryable();

        if (typeof(TAbela) == typeof(Categoria))
            return (IQueryable<TAbela>)DataBaseFake.GetCategorias().AsQueryable();
        
        if (typeof(TAbela) == typeof(Servico))
            return (IQueryable<TAbela>)DataBaseFake.GetServicos().AsQueryable();



        throw new NotImplementedException("Tabela Fake não configurada");
    }

    public virtual IQueryable<T> Consultar()
    {
        // throw new NotImplementedException();
        return Consultar<T>();
    }

#pragma warning disable CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
    public async virtual Task<List<T>> ObterTodos()
#pragma warning restore CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
    {
        Func<List<T>> dados = () =>
        {
            var result = Consultar<T>().ToList();
            return result;
        };
        var task = new Task<List<T>>(dados);
        task.Start();
        return task.Result.ToList<T>();
    }
    #endregion

    #region Métodos
    public virtual Task Adicionar(T entity)
    {

        //var result = _task.Result;
        //await _task.Wait();
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

    public void Dispose()
    {
        //throw new NotImplementedException();
        return;
    }

    public Task<T> ObterPorId(Guid id)
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
    #endregion
}

