using DevFreela.Application.Commands.Projects.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators.ProjectValidator
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(100)
                    .WithMessage("Tamanho máximo é 100 caracteres.");

            RuleFor(p => p.Description)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.");

            RuleFor(p => p.IdClient)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.");

            RuleFor(p => p.IdFreelancer)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.");

            RuleFor(p => p.TotalCost)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .GreaterThanOrEqualTo(1000)
                    .WithMessage("O projeto deve custar pelo menos R$1.000");
        }
    }
}
