using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class LessonTypeValidator : AbstractValidator<LessonType>
	{
		public LessonTypeValidator()
		{
			RuleFor(x => x.LessonTypeId)
			.GreaterThan(-1)
			.WithMessage("LessonTypeId should be greater than - 1");

			RuleFor(x => x.Name).Length(1,65)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");


		}
	}
}
