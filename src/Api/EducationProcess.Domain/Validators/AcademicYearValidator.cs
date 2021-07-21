using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class AcademicYearValidator : AbstractValidator<AcademicYear>
    {
        public AcademicYearValidator()
        {
            RuleFor(x => x.BeginingYear).GreaterThan((short) 2020).GreaterThanOrEqualTo(x => x.EndingYear);
            RuleFor(x => x.EndingYear).GreaterThan((short)2020).GreaterThanOrEqualTo(x => x.BeginingYear);
        }
    }
}