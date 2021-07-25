using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class SemesterDisciplineValidator : AbstractValidator<SemesterDiscipline>
    {
        public SemesterDisciplineValidator()
        {
            RuleFor(x => x.Description).Length(1, 300)
                .When(x => x.Description != null)
                    .WithMessage("Description  length should contain from 000 to 000 symbols");
        }
    }
}