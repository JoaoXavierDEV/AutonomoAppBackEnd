using AutonomoApp.Business.Models;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Interfaces.IService;

public interface ICategoriaService
{
    Task AdicionarCategoria(Categoria categoria);
    Task AdicionarSubcategoria(Subcategoria subCategoria);
}