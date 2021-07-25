using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class AudienceValidator : AbstractValidator<Audience>
    {
        public AudienceValidator()
        {
            RuleFor(x => x.Name)
                .Length(1, 65).When(x => x.Name != null)
                    .WithMessage("Name length is 1-65");

            RuleFor(x => x.Number)
                .NotEmpty()
                    .WithMessage("Number should not be empty")
                .Length(1, 5)
                    .WithMessage("Number should contain from 1 to 5 symbols");
        }
    }
}