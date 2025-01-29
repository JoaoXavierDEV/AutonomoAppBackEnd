//using AutoMapper;
//using AutonomoApp.Business.Interfaces.IRepository;
//using AutonomoApp.Business.Models;

//#nullable disable
//namespace AutonomoApp.Framework.Extensions
//{
//    public static class ViewModelExtensions
//    {
//        private static Categoria cat = new Categoria();
//        private static readonly IMapper _mapper;

//        public static T ToViewModel<T>(this EntityBase owner) where T : class // viewmodelBase
//        {
//            try
//            {

//                return owner == null ? null : (Activator.CreateInstance(typeof(T), owner) as T);
//            }
//            catch (Exception ex)
//            {

//                throw;
//            }
//        }

//        public static T ToModel<T>(this EntityBase owner, Func<Guid, T> function)
//        {
//            try
//            {
//                return owner == null ? default(T) : function(owner.Id);
//            }
//            catch (Exception)
//            {

//                return default(T);
//            }
//        }
//        public static T ToModel<T>(this IRepository<T> owner, /*Viewmodelbase*/ Guid id) where T : EntityBase
//        {
//            try
//            {
//                return owner.ObterPorId(id).Result;
//            }
//            catch (Exception)
//            {

//                return default(T);
//            }
//        }

//    }

//    public class ViewModelBase<T,E> where T : EntityBase where E : IRepository<T>, new()
//    {
//        public Guid Id { get; set; }

//        private readonly IMapper _mapper;

//        public ViewModelBase(IMapper mapper)
//        {
//            _mapper = mapper;
//        }

//        public T ToViewModelConcept()
//        {
//            return (T)Activator.CreateInstance(typeof(T));
//        }


//    }
//}
