using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AutonomoApp.Business.Models;

public abstract class Pessoa : EntityBase
{
    public virtual string? Nome { get; set; }
    public virtual IEnumerable<ServicoSolicitado>? HistoricoDePedidos { get; private set; } = Enumerable.Empty<ServicoSolicitado>().AsQueryable();
    public virtual Endereco? Endereco { get; set; }
    public virtual string? Documento { get; set; }
    public virtual TipoDocumentoEnum TipoDocumento { get; set; }


    public virtual string GetDocumento() => string.Format($"{TipoDocumento.GetEnumDescription()} {Documento}");
    public virtual void AddServicoHistoricoPedidos(ServicoSolicitado ServicoSolicitado)
    {
        HistoricoDePedidos ??= Enumerable.Empty<ServicoSolicitado>();
        HistoricoDePedidos?.Append(ServicoSolicitado);
    }

}