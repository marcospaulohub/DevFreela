using DevFreela.Application.Commands.Skills.InsertSkill;
using FluentValidation;

namespace DevFreela.Application.Validators.SkillValidator
{
    public class InsertSkillValidator : AbstractValidator<InsertSkillCommand>
    {
        public InsertSkillValidator()
        {
            RuleFor(s => s.Description)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(80)
                    .WithMessage("Tamanho máximo é 80 caracteres.");
        }
    }
}
