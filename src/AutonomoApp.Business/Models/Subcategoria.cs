using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutonomoApp.Business.Extensions;

#nullable disable
namespace AutonomoApp.Business.Models;
public class Subcategoria : EntityBase
{
    public virtual int SubCategoriaEnum { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Descricao { get; set; }
}
