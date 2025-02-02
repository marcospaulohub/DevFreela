using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Messages.ProjectMessages;
using FluentValidation;

namespace DevFreela.Application.Validators.ProjectValidator
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage(ProjectMsgs.GetTitleNotEmpty())
                .MaximumLength(100)
                    .WithMessage(ProjectMsgs.GetTitleMaxLength());

            RuleFor(p => p.Description)
                .NotEmpty()
                    .WithMessage(ProjectMsgs.GetDescriptionNotEmpty());

            RuleFor(p => p.IdClient)
                .NotEmpty()
                    .WithMessage(ProjectMsgs.GetText("IdClientNotEmpty"));

            RuleFor(p => p.IdFreelancer)
                .NotEmpty()
                    .WithMessage(ProjectMsgs.GetText("IdFreelancerNotEmpty"));

            RuleFor(p => p.TotalCost)
                .NotEmpty()
                    .WithMessage(ProjectMsgs.GetText("TotalCostNotEmpty"))
                .GreaterThanOrEqualTo(1000)
                    .WithMessage(ProjectMsgs.GetText("TotalCostMinLength"));
        }
    }
}
