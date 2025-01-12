using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Notificacoes;
using AutonomoApp.WebApi.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutonomoApp.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
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
            var tt = new CustomResponseDTO(ModelState, result);

            if (OperacaoValida())
            {
                return Ok(tt);
                
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(tt);

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
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
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
