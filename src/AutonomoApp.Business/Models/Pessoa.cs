using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AutonomoApp.Business.Models;

public abstract class Pessoa : EntityBase
{
    public virtual string? Nome { get; set; }
    public virtual IEnumerable<ServicoSolicitado> HistoricoDePedidos { get; set; } = Enumerable.Empty<ServicoSolicitado>();
    public virtual Endereco? Endereco { get; set; }
    public virtual string? Documento { get; set; }
    public virtual TipoDocumentoEnum TipoDocumento { get; protected set;}
    public Conta Conta { get; set; }
    public virtual string GetDocumento() => string.Format($"{TipoDocumento.GetEnumDescription()} {Documento}");
    public virtual void AddServicoHistoricoPedidos(ServicoSolicitado ServicoSolicitado)
    {
        HistoricoDePedidos ??= Enumerable.Empty<ServicoSolicitado>();
        HistoricoDePedidos = HistoricoDePedidos.Append(ServicoSolicitado);
    }
    public virtual bool PrestaServicos() => HistoricoDePedidos.Any(x => x.Servico.AnuncioAtivo);

    protected Pessoa()
    {
        HistoricoDePedidos = Enumerable.Empty<ServicoSolicitado>();
    }

}