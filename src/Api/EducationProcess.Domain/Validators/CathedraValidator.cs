using EducationProcess.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Validators
{
    class CathedraValidator : AbstractValidator<Cathedra>
    {
        public CathedraValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name should not be empty").Length(1, 74).WithMessage("Name should contain from 1 to 75 symbols");
            RuleFor(x=>x.NameAbbreviation).Length(1,10).WithMessage("Name abbreviation should contain from 1 to 10 symbols");
        }
    }
}
