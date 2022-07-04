using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutonomoApp.Business.Extensions;

namespace AutonomoApp.Business.Models;
#nullable disable
public class Subcategoria : EntityBase
{
    public new int Id { get; set; }
    public int IdEnum { get; set; }
    public string Nome { get; set; }
    public virtual string Descricao { get; set; }
}




