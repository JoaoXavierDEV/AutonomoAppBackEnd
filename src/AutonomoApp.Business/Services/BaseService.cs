﻿using AutonomoApp.Business.Models;
using AutonomoApp.Framework.Interfaces;
using AutonomoApp.Framework.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace AutonomoApp.Business.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : EntityBase
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }
}
