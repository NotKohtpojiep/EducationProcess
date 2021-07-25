using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class FederalStateEducationalStandardValidator : AbstractValidator<FederalStateEducationalStandard>
    {
        public FederalStateEducationalStandardValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 120)
                    .WithMessage("Name  length should contain from 1 to 120 symbols");
        }
    }
}