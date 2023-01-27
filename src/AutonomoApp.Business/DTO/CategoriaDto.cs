using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.DTO;

public record struct CategoriaDto
{
    public int CatEnumId { get; }
    public string Nome { get; }
    public string Descricao { get; }

    public CategoriaDto(Categoria categoria)
    {
        CatEnumId = (int)categoria.CategoriaEnum;
        Nome = categoria.Nome;
        Descricao = categoria.Descricao;
    }
}