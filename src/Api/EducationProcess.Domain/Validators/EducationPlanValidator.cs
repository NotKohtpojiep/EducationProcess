using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class EducationPlanValidator : AbstractValidator<EducationPlan>
    {
        public EducationPlanValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 65)
                    .WithMessage("Name  length should contain from 1 to 65 symbols");

            RuleFor(x => x.Description)
                .Length(1, 300).When(x => x.Description != null)
                    .WithMessage("Description  length should contain from 1 to 300 symbols");
        }
    }
}