using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class DisciplineValidator : AbstractValidator<Discipline>
    {
        public DisciplineValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 125)
                    .WithMessage("Name length should be 1-125");

            RuleFor(x => x.DisciplineIndex)
                .NotEmpty()
                    .WithMessage("DisciplineIndex should not be empty")
                .Length(1, 10)
                    .WithMessage("DisciplineIndex length should contain from 1 to 10 symbols");

            RuleFor(x => x.Description)
                .Length(1, 500).When(x => x.Description != null)
                    .WithMessage("Description length should contain from 1 to 500 symbols");
        }
    }
}
