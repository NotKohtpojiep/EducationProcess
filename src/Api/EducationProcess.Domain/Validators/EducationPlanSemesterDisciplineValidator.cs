using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class EducationPlanSemesterDisciplineValidator : AbstractValidator<EducationPlanSemesterDiscipline>
	{
		public EducationPlanSemesterDisciplineValidator()
		{

			RuleFor(x => x.EducationPlanId)
			.GreaterThan(-1)
			.WithMessage("EducationPlanId should be greater than - 1");

			RuleFor(x => x.SemesterDisciplineId)
			.GreaterThan(-1)
			.WithMessage("SemesterDisciplineId should be greater than - 1");


		}
	}
}
