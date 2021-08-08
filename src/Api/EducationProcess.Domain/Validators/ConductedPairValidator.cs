using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class ConductedPairValidator : AbstractValidator<ConductedPair>
    {
        public ConductedPairValidator()
        {
            RuleFor(x => x.ScheduleDisciplineId)
                .NotNull().When(x => x.ScheduleDisciplineReplacementId == null)
                    .WithMessage("ScheduleDisciplineId should not be empty, if ScheduleDisciplineReplacementId is null");
            RuleFor(x => x.ScheduleDisciplineId)
                .Null().When(x => x.ScheduleDisciplineReplacementId != null)
                    .WithMessage("ScheduleDisciplineId should be empty, if ScheduleDisciplineReplacementId is not null");

            RuleFor(x => x.ScheduleDisciplineReplacementId)
                .NotNull().When(x => x.ScheduleDisciplineId == null)
                    .WithMessage("ScheduleDisciplineReplacementId should not be empty, if ScheduleDisciplineId is null");
            RuleFor(x => x.ScheduleDisciplineReplacementId)
                .Null().When(x => x.ScheduleDisciplineId != null)
                    .WithMessage("ScheduleDisciplineReplacementId should be empty, if ScheduleDisciplineId is not null");
        }
    }
}