using EducationProcess.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Validators
{
    class ConductedPairValidator : AbstractValidator<ConductedPair>
    {
        public ConductedPairValidator()
        {
            RuleFor(x=>x.ScheduleDisciplineId)
                .GreaterThan(-1)
                .When(x => x.ScheduleDisciplineId != null)
                .WithMessage("ScheduleDisciplineId shold be greater than -1");
            RuleFor(x=>x.ScheduleDisciplineReplacementId).GreaterThan(-1)
                .When(x=>x.ScheduleDisciplineReplacementId != null)
                .WithMessage("ScheduleDisciplineReplacementId shold be greater than -1");
            RuleFor(x => x.LessonTypeId).GreaterThan(-1)
                .WithMessage("LessonTypeId shold be greater than -1");

        }
    }
}
