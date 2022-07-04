using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Services;

#nullable disable
namespace AutonomoApp.Business.Models;

public class Categoria : EntityBase
{
    public new int Id { get; set; }
    public int IdEnum { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public virtual List<Subcategoria> Subcategorias { get; set; }
}


