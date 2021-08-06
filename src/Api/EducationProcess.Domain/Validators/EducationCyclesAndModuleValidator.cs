using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class EducationCyclesAndModuleValidator : AbstractValidator<EducationCyclesAndModule>
    {
        public EducationCyclesAndModuleValidator()
        {
            RuleFor(x => x.EducationCycleIndex)
                .NotEmpty()
                    .WithMessage("EducationCycleIndex should not be empty")
                .Length(1, 10)
                    .WithMessage("EducationCycleIndex length should contain from 1 to 10 symbols");

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 120)
                    .WithMessage("Name  length should contain from 1 to 120 symbols");

            RuleFor(x => x.Description)
                .Length(1, 300).When(x => x.Description != null)
                    .WithMessage("Description  length should contain from 1 to 300 symbols");
        }
    }
}