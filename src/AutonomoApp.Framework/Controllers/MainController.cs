using AutonomoApp.Framework.Interfaces;
using AutonomoApp.Framework.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutonomoApp.Framework.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase, IController
    {
        private readonly INotificador _notificador;
        public readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificador notificador,
                                 IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            var respondeDTO = new CustomResponseDTO(ModelState, result);

            if (OperacaoValida())
            {
                return Ok(respondeDTO);
                
            }

            return BadRequest(new ValidationProblemDetails(new ModelStateDictionary(ModelState))
            {
                Title = "Erro de validação",
                Status = 400,
                Detail = "Ocorreu um ou mais erros de validação",
                Instance = HttpContext.Request.Path,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",

            });

            return BadRequest(respondeDTO);

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });



        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                this.NotificarErro(errorMsg);
            }
        }



        protected void LimparErroProcessamento()
        {
            _notificador.Limpar();
        }

        /// <summary>
        /// Notificar erro
        /// </summary>
        /// Manter [ApiExplorerSettings(IgnoreApi = true)] para que não seja visível no swagger 
        /// <param name="mensagem"></param>
        [ApiExplorerSettings(IgnoreApi = true)]
        public void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }



    }

    public record struct CustomResponseDTO
    {
        public bool Error { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; }
        public int ErrorCount { get; set; } = 0;

        public CustomResponseDTO(ModelStateDictionary modelState, object data)
        {
            Error = modelState.IsValid;
            Data = data;
            ErrorCount = modelState.ErrorCount;
            Message = string.Join(" || ", modelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage));
        }

        //public CustomResponseDTO(AbstractValidator<T> validation)
        //{
        //    Error = validation.va;
        //    Data = categoriaViewModel;
        //    ErrorCount = modelState.ErrorCount;
        //    Message = string.Join(" || ", modelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage));
        //}

        public override string ToString()
        {
            return string.Format("Erros: {0} -- Mensagem: {1}", ErrorCount, Message);
        }
    }
}
