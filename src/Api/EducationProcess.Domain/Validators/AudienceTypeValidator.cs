using EducationProcess.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Validators
{
    class AudienceTypeValidator: AbstractValidator<AudienceType>
    {
        public AudienceTypeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty");

        }
    }
}
