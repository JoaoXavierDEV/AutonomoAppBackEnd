using System.Collections.Generic;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models;

public abstract class Pessoa : EntityBase
{
    public virtual string Nome { get; set; }
    public virtual List<ServicoSolicitacao>? HistoricoDePedidos{ get; }
    public string Documento { get; set; }
    public virtual TipoDocumentoEnum TipoDocumentoEnum { get; set; }


    public virtual string GetDocumento() => string.Format($"{TipoDocumentoEnum.GetEnumDescription()} {Documento}");
    public virtual void AddServicoHistoricoPedidos(ServicoSolicitacao servicoSolicitacao)
    {
        HistoricoDePedidos?.Add(servicoSolicitacao);
    }
    
}