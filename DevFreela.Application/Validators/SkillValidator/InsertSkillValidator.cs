using DevFreela.Application.Commands.Skills.InsertSkill;
using DevFreela.Core.Messages.SkillMessages;
using FluentValidation;

namespace DevFreela.Application.Validators.SkillValidator
{
    public class InsertSkillValidator : AbstractValidator<InsertSkillCommand>
    {
        public InsertSkillValidator()
        {
            RuleFor(s => s.Description)
                .NotEmpty()
                    .WithMessage(SkillMsgs.GetDescriptionNotEmpty())
                .MaximumLength(80)
                    .WithMessage(SkillMsgs.GetDescriptionMaxLength());
        }
    }
}
