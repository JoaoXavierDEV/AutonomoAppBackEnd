using AutonomoApp.Framework.Notificacoes;
using System.Collections.Generic;

namespace AutonomoApp.Framework.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}