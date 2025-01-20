using System.ComponentModel.DataAnnotations;

namespace AutonomoApp.Identidade.Models
{
    ///
    /// Summary:
    ///     ViewModel para registrar usuário
    ///
    /// Parameters:
    ///   idContribuicao:
    ///     id da Contribuição
    ///
    ///   idParticipantePorPlano:
    ///     id do Participante por plano
    ///
    ///   nomeVar1:
    ///     nome para a opção de ordem 1 no dicionário de saída
    ///
    ///   nomeVar2:
    ///     nome para a opção de ordem 2 no dicionário de saída
    ///
    ///   nomeVar3:
    ///     nome para a opção de ordem 3 no dicionário de saída
    ///
    ///   Saida:
    ///     dicionário de saída que contém as opções
    ///
    ///   vData:
    ///     Ano/Mês da contribuição (opcional)
    ///
    ///   nomeVar4:
    ///     nome para o campo "Ativo" no dicionário
    ///
    /// Returns:
    ///     true se a Contribuição foi encontrada e tem opções
    ///
    /// Remarks:
    ///     Este método está obsoleto, pois não realiza a busca exatamente como o TotalPrev
    ///     realiza, podendo falhar dependendo do cenário, para evitar problemas utilize
    ///     uma das sobrecargas abaixo que já realizam a busca exatamente conforme o TotalPrev:
    ///
    ///
    ///     - CM.CMPrevWeb.CorePrev.Domain.Services.ITotalPrevService.OpContrib(System.Int32,System.Int32,System.Nullable{System.DateTime},System.Decimal@)
    ///
    ///
    ///     - CM.CMPrevWeb.CorePrev.Domain.Services.ITotalPrevService.OpContrib(System.Int32,System.Int32,System.Nullable{System.DateTime},System.Decimal@,System.Decimal@)
    ///
    ///
    ///     - CM.CMPrevWeb.CorePrev.Domain.Services.ITotalPrevService.OpContrib(System.Int32,System.Int32,System.Nullable{System.DateTime},System.Decimal@,System.Decimal@,System.Decimal@)
    [Obsolete("ViewModel Obsoleta - AA-TCC ")]
    public class RegistrarUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; } = null!;

        /// Pessoa

        public bool PessoaFisica { get; set; } = true;
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime Nascimento { get; set; }
        //public Endereco Endereco { get; set; }
    }



    public class UsuarioRegistro
    {
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //public string Nome { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }

    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }

    public class UsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }

    public class ClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
