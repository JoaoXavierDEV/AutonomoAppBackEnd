using System;
using System.Collections.Generic;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models
{
    public class ServicoSolicitacao : EntityBase
    {
        public Servico ServicoSolicitado { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime DataConclusaoEstimada { get; set; }
        

        public ServicoSolicitacao()
        {
             DataSolicitacao = DateTime.Now;
             
        }
    }
}
