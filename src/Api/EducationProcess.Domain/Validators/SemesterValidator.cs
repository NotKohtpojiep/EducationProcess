using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class SemesterValidator : AbstractValidator<Semester>
    {
        public SemesterValidator()
        {
            RuleFor(x => x.Number)
                .LessThan((byte)20)
                    .WithMessage("Number should be less than 20");

            RuleFor(x => x.WeeksCount)
                .LessThanOrEqualTo((byte)100)
                    .WithMessage("WeeksCount should be less greater than - 100");
        }
    }
}