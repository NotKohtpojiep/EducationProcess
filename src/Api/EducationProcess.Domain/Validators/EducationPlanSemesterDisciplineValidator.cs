using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class EducationPlanSemesterDisciplineValidator : AbstractValidator<EducationPlanSemesterDiscipline>
    {
        public EducationPlanSemesterDisciplineValidator()
        {
            RuleFor(x => x.EducationPlanId)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("EducationPlanId should be greater or equal 0");
            RuleFor(x => x.SemesterDisciplineId)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("SemesterDisciplineId should be greater or equal 0");
        }
    }
}