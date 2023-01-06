using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutonomoApp.Business.Extensions;

namespace AutonomoApp.Business.Models;
#nullable disable
public class Subcategoria : EntityBase
{
   // public new int Id { get; set; }
    public virtual int? SubCatEnumId { get; set; }
    public virtual string? Nome { get; set; }
    public virtual string Descricao { get; set; }
    //public virtual Categoria Categoria { get; set; } = new Categoria();

    /* EF */
    public virtual Guid? CategoriaId { get; set; }
    public virtual Guid? ServicoId { get; set; }
    public virtual IEnumerable<ServicoSubCategoria>? ServicoSubCategoria { get; set; } //= new List<Servico>();
}
