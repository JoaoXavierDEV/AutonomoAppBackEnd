using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models;

public class PessoaJuridica : Pessoa
{
    public string NomeEmpresa { get; set; }

    public PessoaJuridica()
    {
        TipoDocumentoEnum = TipoDocumentoEnum.PessoaJuridica;
    }
}