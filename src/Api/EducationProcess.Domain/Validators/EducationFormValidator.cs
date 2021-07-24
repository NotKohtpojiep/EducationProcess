using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class EducationFormValidator : AbstractValidator<EducationForm>
	{
		public EducationFormValidator()
		{
			RuleFor(x => x.EducationFormId)
			.GreaterThan(-1)
			.WithMessage("EducationFormId should be greater than - 1");

			RuleFor(x => x.Name).Length(1,100)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 1 to 100 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");


		}
	}
}
