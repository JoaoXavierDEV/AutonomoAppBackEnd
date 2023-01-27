using System;

namespace AutonomoApp.Business.Models;
#nullable disable
public class ServicoSolicitado : EntityBase
{
    public virtual Pessoa ClienteSolicitante { get; set; }
    public virtual Servico Servico { get; set; }
    public DateTime DataSolicitacao { get; }
    public DateTime? DataConclusao { get; set; }
    public DateTime DataConclusaoEstimada { get; set; }

    public ServicoSolicitado()
    {
        DataSolicitacao = DateTime.Now;

    }
}
