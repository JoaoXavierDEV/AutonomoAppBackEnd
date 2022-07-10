using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Services;

//#nullable enable
namespace AutonomoApp.Business.Models;

public class Categoria : EntityBase
{
    public virtual int? CatEnumId { get; set; }
    public virtual string? Nome { get; set; }
    public virtual string? Descricao { get; set; }

    /* EF */
    public virtual Guid? SubcategoriasId { get; set; }
    public virtual IEnumerable<ServicoCategoria>? ServicosCategoria { get; set; }// = new List<Servico>();
}
