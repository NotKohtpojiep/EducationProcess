using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class EducationFormValidator : AbstractValidator<EducationForm>
    {
        public EducationFormValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 100)
                    .WithMessage("Name  length should contain from 1 to 100 symbols");
        }
    }
}