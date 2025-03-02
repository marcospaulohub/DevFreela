using DevFreela.Application.Commands.Users.InsertUser;
using DevFreela.Core.Messages.UserMessages;
using FluentValidation;
using System;

namespace DevFreela.Application.Validators.UserValidator
{
    public class CreateUserValidator : AbstractValidator<InsertUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.FullName)
                .NotEmpty()
                    .WithMessage(UserMsgs.GetFullnameNotEmpty())
                .MaximumLength(200)
                    .WithMessage(UserMsgs.GetFullnameMaxLength());

            RuleFor(u => u.Email)
                .NotEmpty()
                    .WithMessage(UserMsgs.GetEmailNotEmpty())
                .MaximumLength(200)
                    .WithMessage(UserMsgs.GetEmailMaxLength())
                .EmailAddress()
                    .WithMessage(UserMsgs.GetEmailInvalid());

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                    .WithMessage(UserMsgs.GetBirthDateNotEmpty())
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage(UserMsgs.GetBirtDateMinAge());

            RuleFor(u => u.Password)
                .NotEmpty()
                    .WithMessage(UserMsgs.GetPasswordNotEmpty())
                .MaximumLength(20)
                    .WithMessage(UserMsgs.GetPasswordMaxLength());

            RuleFor(u => u.Role)
                .NotEmpty()
                    .WithMessage(UserMsgs.GetRoleNotEmpty())
                .MaximumLength(20)
                    .WithMessage(UserMsgs.GetRoleMaxLength());
        }
    }
}
