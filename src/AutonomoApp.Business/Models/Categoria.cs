using AutonomoApp.Business.Models.Enums;
using System;
using System.Collections.Generic;

#nullable disable
namespace AutonomoApp.Business.Models;

public class Categoria : EntityBase
{
    public virtual CategoriaEnum CategoriaEnum { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Descricao { get; set; }
    public virtual IEnumerable<Subcategoria> Subcategorias { get; set; }
}
