using FluentValidation;

namespace AutonomoApp.Business.Models.Validations;

public class CategoriaValidation : AbstractValidator<Categoria>
{
    public CategoriaValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(5,20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório");
    }
}

public class SubCategoriaValidation : AbstractValidator<Subcategoria>
{
    public SubCategoriaValidation()
    {
        RuleFor(x => x.Descricao)
        .NotEmpty().WithMessage("{PropertyName} é obrigatório");
    }
}