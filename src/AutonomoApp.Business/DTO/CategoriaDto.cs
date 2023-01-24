using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.DTO;

public record struct CategoriaDto
{
    public int CatEnumId { get; }
    public string Nome { get; }
    public string Descricao { get; }

    public CategoriaDto(Categoria categoria)
    {
        CatEnumId = categoria.CategoriaEnum ?? 0;
        Nome = categoria.Nome;
        Descricao = categoria.Descricao;
    }
}