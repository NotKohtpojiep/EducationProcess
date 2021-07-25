using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class ReceivedEducationValidator : AbstractValidator<ReceivedEducation>
    {
        public ReceivedEducationValidator()
        {
            RuleFor(x => x.StudyPeriodMonths)
                .LessThan((ushort)100)
                    .WithMessage("StudyPeriodMonths should be less than - 100");
        }
    }
}