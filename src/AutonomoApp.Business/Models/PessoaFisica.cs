using System;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models;

public sealed class PessoaFisica : Pessoa
{
    public DateTime Nascimento { get; set; }
    public PessoaFisica()
    {
        TipoDocumento = Enums.TipoDocumentoEnum.PessoaFisica;
    }

    public int GetIdadeNoAno()
    {
        return (DateTime.Now.Year - Nascimento.Year);
    }

}