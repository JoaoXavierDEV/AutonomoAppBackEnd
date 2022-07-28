using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.DTO;

public record struct SubCategoriaDto
{
    public int SubCatEnumId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public SubCategoriaDto(Subcategoria subcategoria)
    {
        SubCatEnumId = subcategoria.SubCatEnumId.Value;
        Nome = subcategoria.Nome;
        Descricao = subcategoria.Descricao;
    }
}