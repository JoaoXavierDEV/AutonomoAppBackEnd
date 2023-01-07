﻿using AutonomoApp.Business.Interfaces.IRepository;
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
    public virtual IQueryable<TAbela> Consultar<TAbela>() where TAbela : EntityBase
    {
        //throw new NotImplementedException();        
        // var tt = TAbela.Equals(new Categoria());
        return new List<TAbela>().AsQueryable();
    }

    public virtual IQueryable<T> Consultar()
    {
        // throw new NotImplementedException();
        return Consultar<T>();
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

    public virtual Task<List<T>> ObterTodos()
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

