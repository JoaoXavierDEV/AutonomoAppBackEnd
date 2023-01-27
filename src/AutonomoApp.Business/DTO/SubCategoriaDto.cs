using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.DTO;

public record struct SubCategoriaDto
{
    public int SubCatEnumId { get;  }
    public string Nome { get;  }
    public string Descricao { get;  }

    public SubCategoriaDto(Subcategoria subcategoria)
    {
        SubCatEnumId = (int)subcategoria.SubCategoriaEnum;
        Nome = subcategoria.Nome;
        Descricao = subcategoria.Descricao;
    }
}