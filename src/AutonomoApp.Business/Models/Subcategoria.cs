using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutonomoApp.Business.Extensions;

namespace AutonomoApp.Business.Models;
#nullable disable
public class Subcategoria : EntityBase
{
    public virtual int? SubCatEnumId { get; set; }
    public virtual string? Nome { get; set; }
    public virtual string Descricao { get; set; }
    // public virtual Categoria Categoria { get; set; } //= new Categoria();
}
