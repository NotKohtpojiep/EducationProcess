using EducationProcess.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Validators
{
    class EducationCyclesAndModuleValidator : AbstractValidator<EducationCyclesAndModule>
    {
        public EducationCyclesAndModuleValidator()
        {

            RuleFor(x => x.EducationCycleIndex).Length(1, 10)
                .When(x => x.EducationCycleIndex != null)
                .WithMessage("EducationCycleIndex  length should contain from 1 to 10 symbols")
                .NotEmpty()
                .WithMessage("EducationCycleIndex should not be empty");

            RuleFor(x => x.Name).Length(1, 120)
                .When(x => x.Name != null)
                .WithMessage("Name  length should contain from 0 to 120 symbols")
                .NotEmpty()
                .WithMessage("Name should not be empty");

            RuleFor(x => x.Description).Length(0, 300)
                .When(x => x.Description != null)
                .WithMessage("Description  length should contain from 0 to 300 symbols")
                .WithMessage("Description should not be empty");

            RuleFor(x => x.EducationCycleParentId)
                .GreaterThan(-1)
                .When(x => x.EducationCycleParentId != null)
                .WithMessage("EducationCycleParentId should be greater than - 1");

        }
    }
}
