using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class ConductedPairValidator : AbstractValidator<ConductedPair>
    {
        public ConductedPairValidator()
        {
            RuleFor(x => x.ScheduleDisciplineId)
                .NotEmpty().When(x => x.ScheduleDisciplineReplacementId == null)
                    .WithMessage("ScheduleDisciplineId should not be empty, if ScheduleDisciplineReplacementId is null")
                .Empty().When(x => x.ScheduleDisciplineReplacementId != null)
                    .WithMessage("ScheduleDisciplineId should be empty, if ScheduleDisciplineReplacementId is not null");

            RuleFor(x => x.ScheduleDisciplineReplacementId)
                .NotEmpty().When(x => x.ScheduleDisciplineId == null)
                .WithMessage("ScheduleDisciplineReplacementId should not be empty, if ScheduleDisciplineId is null")
                .Empty().When(x => x.ScheduleDisciplineId != null)
                .WithMessage("ScheduleDisciplineReplacementId should be empty, if ScheduleDisciplineId is not null");
        }
    }
}