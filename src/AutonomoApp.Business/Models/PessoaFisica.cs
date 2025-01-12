using System;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models;

public sealed class PessoaFisica : Pessoa
{
    public DateTime Nascimento { get; set; }
    public PessoaFisica()
    {
        TipoDocumento = Enums.TipoDocumentoEnum.PessoaFisica;
        Conta = new Conta()
        {
            PlanoVitalicio = true,
            PremiumAtivo = true,
            UsuarioVerificado = true,
        };
    }

    /// <summary>
    /// dddd
    /// </summary>
    /// <remarks>adsasdasada</remarks>
    /// <returns>Retorna a Idade no Ano</returns>
    public int GetIdadeNoAno()
    {
        return (DateTime.Now.Year - Nascimento.Year);
    }

}