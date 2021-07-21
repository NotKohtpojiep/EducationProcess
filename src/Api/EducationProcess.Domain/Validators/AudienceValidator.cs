using EducationProcess.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Validators
{
    class AudienceValidator:AbstractValidator<Audience>
    {
        public AudienceValidator()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number should not be empty").Length(1, 5).WithMessage("Number should contain from 1 to 5 symbols");
        }
    }
}
