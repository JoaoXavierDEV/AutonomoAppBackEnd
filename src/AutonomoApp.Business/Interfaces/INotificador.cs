using AutonomoApp.Business.Notificacoes;
using System.Collections.Generic;

namespace AutonomoApp.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}