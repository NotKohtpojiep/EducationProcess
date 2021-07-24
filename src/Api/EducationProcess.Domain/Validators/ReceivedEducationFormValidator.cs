using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class ReceivedEducationFormValidator : AbstractValidator<ReceivedEducationForm>
	{
		public ReceivedEducationFormValidator()
		{
			RuleFor(x => x.ReceivedEducationFormId)
			.GreaterThan(-1)
			.WithMessage("ReceivedEducationFormId should be greater than - 1");

			RuleFor(x => x.EducationFormId)
			.GreaterThan(-1)
			.WithMessage("EducationFormId should be greater than - 1");

			RuleFor(x => x.AdditionalInfo).Length(0, 65)
			.When(x => x.AdditionalInfo != null)
			.WithMessage("AdditionalInfo  length should contain from 000 to 000 symbols");


		}
	}
}
