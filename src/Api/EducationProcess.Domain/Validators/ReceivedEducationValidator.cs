using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class ReceivedEducationValidator : AbstractValidator<ReceivedEducation>
	{
		public ReceivedEducationValidator()
		{
			RuleFor(x => x.ReceivedEducationId)
			.GreaterThan(-1)
			.WithMessage("ReceivedEducationId should be greater than - 1");

			RuleFor(x => x.ReceivedSpecialtyId)
			.GreaterThan(-1)
			.WithMessage("ReceivedSpecialtyId should be greater than - 1");

			RuleFor(x => x.ReceivedEducationFormId)
			.GreaterThan(-1)
			.WithMessage("ReceivedEducationFormId should be greater than - 1");

			RuleFor(x => x.EducationLevelId)
			.GreaterThan(-1)
			.WithMessage("EducationLevelId should be greater than - 1");

			RuleFor(x => x.StudyPeriodMonths)
			.LessThan((short)32000)
			.WithMessage("StudyPeriodMonths should be greater than - 1");


		}
	}
}
