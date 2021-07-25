using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class ReceivedEducationFormValidator : AbstractValidator<ReceivedEducationForm>
    {
        public ReceivedEducationFormValidator()
        {
            RuleFor(x => x.AdditionalInfo)
                .Length(1, 300).When(x => x.AdditionalInfo != null)
                    .WithMessage("AdditionalInfo  length should contain from 000 to 000 symbols");
        }
    }
}