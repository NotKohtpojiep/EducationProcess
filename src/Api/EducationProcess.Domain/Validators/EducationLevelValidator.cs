using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class EducationLevelValidator : AbstractValidator<EducationLevel>
	{
		public EducationLevelValidator()
		{
			RuleFor(x => x.EducationLevelId)
			.GreaterThan(-1)
			.WithMessage("EducationLevelId should be greater than - 1");

			RuleFor(x => x.Name).Length(1,100)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 1 to 100 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");


		}
	}
}
