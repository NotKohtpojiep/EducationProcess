using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class ReceivedSpecialtyValidator : AbstractValidator<ReceivedSpecialty>
    {
        public ReceivedSpecialtyValidator()
        {
            RuleFor(x => x.Qualification)
                .NotEmpty()
                    .WithMessage("Qualification should not be empty")
                .Length(1, 100)
                    .WithMessage("Qualification length should contain from 000 to 000 symbols");
        }
    }
}