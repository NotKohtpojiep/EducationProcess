using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class AudienceTypeValidator : AbstractValidator<AudienceType>
    {
        public AudienceTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1,100)
                    .WithMessage("Name should have 1-100 character size");

            RuleFor(x => x.Description)
                .Length(1,300).When(x => x.Description != null)
                    .WithMessage("Name should have 1-300 character size");
        }
    }
}