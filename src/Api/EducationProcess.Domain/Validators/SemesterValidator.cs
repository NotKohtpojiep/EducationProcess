using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class SemesterValidator : AbstractValidator<Semester>
	{
		public SemesterValidator()
		{
			RuleFor(x => x.SemesterId)
			.GreaterThan(-1)
			.WithMessage("SemesterId should be greater than - 1");

			RuleFor(x => x.Number)
			.LessThan((byte)127)
			.WithMessage("Number should be greater than - 1");

			RuleFor(x => x.WeeksCount)
			.LessThan((byte)127)
			.WithMessage("WeeksCount should be greater than - 1");


		}
	}
}
