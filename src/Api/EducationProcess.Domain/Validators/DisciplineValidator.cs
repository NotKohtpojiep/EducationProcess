using EducationProcess.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Validators
{
    class DisciplineValidator: AbstractValidator<Discipline>
    {
        public DisciplineValidator()
        {
            RuleFor(x=>x.Description).Length(0,500).When(x=>x.Description != null).WithMessage("Description length should contain from 0 to 500 symbols");
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name should not be empty").Length(1,125);
            RuleFor(x => x.EducationCycleId).GreaterThan(-1).WithMessage("EducationCycleId should be greater than -1");
            RuleFor(x => x.CathedraId).GreaterThan(-1).When(x=>x.CathedraId != null).WithMessage("CathedraId should be greater than -1");
            RuleFor(x => x.DisciplineIndex).NotEmpty().WithMessage("DisciplineIndex should not be empty").Length(1,10).WithMessage("DisciplineIndex length should contain from 0 to 10 symbols");
        }
    }
}
