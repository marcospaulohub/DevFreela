using DevFreela.Application.Models;
using FluentValidation;

namespace DevFreela.Application.Validators.UserValidator
{
    public class CreateUserValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.FullName)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(200)
                    .WithMessage("Tamanho máximo é 200 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(200)
                    .WithMessage("Tamanho máximo é 200 caracteres.")
                .EmailAddress()
                    .WithMessage("E-mail inválido.");

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Deve ser maior de idade.");
        }
    }
}
