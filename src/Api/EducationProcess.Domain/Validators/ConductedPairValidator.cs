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
            RuleFor(x=>x.ScheduleDisciplineId).GreaterThan(-1).WithMessage("");
            RuleFor(x=>x.ScheduleDisciplineReplacementId).GreaterThan(-1).When(x=>x.ScheduleDisciplineReplacementId != null).WithMessage("");

        }
    }
}
