using System;
using System.Collections.Generic;

//#nullable enable
namespace AutonomoApp.Business.Models;

public class Categoria : EntityBase
{
    public virtual int? CategoriaEnum { get; set; }
    public virtual string? Nome { get; set; }
    public virtual string? Descricao { get; set; }
    public virtual IEnumerable<Subcategoria>? Subcategorias { get; set; }
    public virtual IEnumerable<ServicoCategoria>? ServicosCategoria { get; set; }// = new List<Servico>();

    public void Test()
    {
        ServicosCategoria= new List<ServicoCategoria>() 
        { 
            new ServicoCategoria()
            {
                Categoria = new Categoria() {},
                
            }
        };
    }
}
