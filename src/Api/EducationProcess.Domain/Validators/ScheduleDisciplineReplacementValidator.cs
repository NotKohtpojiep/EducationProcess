using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class ScheduleDisciplineReplacementValidator : AbstractValidator<ScheduleDisciplineReplacement>
	{
		public ScheduleDisciplineReplacementValidator()
		{
			RuleFor(x => x.ScheduleDisciplineReplacementId)
			.GreaterThan(-1)
			.WithMessage("ScheduleDisciplineReplacementId should be greater than - 1");

			RuleFor(x => x.ScheduleDisciplineId)
			.GreaterThan(-1)
			.When(x=>x.ScheduleDisciplineId != null)
			.WithMessage("ScheduleDisciplineId should be greater than - 1");


			RuleFor(x => x.FixedDisciplineId)
			.GreaterThan(-1)
			.WithMessage("FixedDisciplineId should be greater than - 1");

			RuleFor(x => x.AudienceId)
			.GreaterThan(-1)
			.When(x=>x.AudienceId != null)
			.WithMessage("AudienceId should be greater than - 1");


			RuleFor(x => x.CreatedByEmployeeId)
			.GreaterThan(-1)
			.WithMessage("CreatedByEmployeeId should be greater than - 1");

			RuleFor(x => x.ModifiedByEmployeeId)
			.GreaterThan(-1)
			.WithMessage("ModifiedByEmployeeId should be greater than - 1");


		}
	}
}
