using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Models;
using AutonomoApp.Data.Mappings.Identity;
using AutonomoApp.WebApi.Extensions;
using AutonomoApp.WebApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AutonomoApp.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class AuthController : MainController
    {
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public AuthController(INotificador notificador,
                              SignInManager<UsuarioIdentity> signInManager,
                              UserManager<UsuarioIdentity> userManager,
                              IOptions<AppSettings> appSettings,
                              IUser user, ILogger<AuthController> logger) : base(notificador, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        //[EnableCors("Development")]
        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegistrarUsuarioViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new UsuarioIdentity
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
                Pessoa = registerUser.PessoaFisica ? 
                new Business.Models.PessoaFisica
                {
                    Nome = registerUser.Nome,
                    Conta = new Conta(),
                    Endereco = registerUser.Endereco,
                    Nascimento = registerUser.Nascimento,
                    Documento = registerUser.Documento,
                    
                    

                    // Benefícios = new List<Beneficio> { new Beneficio { Codigo = "AFF", Descricao = "Aff kade", Nome = "testeeee", TipoDeBeneficio = Business.Models.Enums.TipoDeBeneficio.Avaliacao} }

                } : 
                new Business.Models.PessoaJuridica
                {

                }
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(user.Email));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario " + loginUser.Email + " logado com sucesso");
                return CustomResponse(await GerarJwt(loginUser.Email));
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email) as UsuarioIdentity;
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}