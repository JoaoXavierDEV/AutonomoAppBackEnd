namespace AutonomoApp.Framework.Interfaces
{
    // public interface IController<P> where P : class, new() // ok
    //public interface IController<TV, TE> where TV : Servico<TE> where TE : class, new() // ok
    //public interface IController<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    public interface IController
    {
        protected void NotificarErro(string mensagem);
    }

    public interface IControllerRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        public void NotificarErro(string mensagem);
    }

    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class, new()
    {

    }

    public class ControllerTest : IControllerRepository<Conta>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void NotificarErro(string mensagem)
        {
            throw new NotImplementedException();
        }
    }

    public class RepoFake : IRepositoryBase<Conta>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class Conta
    {
    }

    public abstract class Servico<T> where T : class, new()
    {
    }

    //[ApiController]
    //public abstract class MainController : ControllerBase, IController<Conta>
}
