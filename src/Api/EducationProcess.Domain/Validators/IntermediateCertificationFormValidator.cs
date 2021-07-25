using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class IntermediateCertificationFormValidator : AbstractValidator<IntermediateCertificationForm>
    {
        public IntermediateCertificationFormValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 120)
                    .WithMessage("Name  length should contain from 000 to 000 symbols");
        }
    }
}