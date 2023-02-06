using System.Collections.Generic;
using System.Threading.Tasks;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.Interfaces.IRepository;

public interface ISubCategoriaRepository : IRepository<Subcategoria>
{
    Task<List<Subcategoria>> ObterTodasSubCategorias();
}