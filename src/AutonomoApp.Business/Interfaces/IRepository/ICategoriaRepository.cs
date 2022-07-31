using System.Collections.Generic;
using System.Threading.Tasks;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.Interfaces.IRepository;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<List<Categoria>> ObterTodasCategorias();
    Task<List<Subcategoria>> ObterTodasCategoriasESubcategorias();
}