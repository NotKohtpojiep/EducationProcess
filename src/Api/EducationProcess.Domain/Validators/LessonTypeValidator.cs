using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
	public class LessonTypeValidator : AbstractValidator<LessonType>
	{
		public LessonTypeValidator()
		{
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1,65)
                    .WithMessage("Name  length should contain from 000 to 000 symbols");
        }
	}
}