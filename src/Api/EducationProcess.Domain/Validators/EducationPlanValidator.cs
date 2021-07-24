using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class EducationPlanValidator : AbstractValidator<EducationPlan>
	{
		public EducationPlanValidator()
		{
			RuleFor(x => x.EducationPlanId)
			.GreaterThan(-1)
			.WithMessage("EducationPlanId should be greater than - 1");

			RuleFor(x => x.FsesCategoryPatitionId)
			.GreaterThan(-1)
			.WithMessage("FsesCategoryPatitionId should be greater than - 1");

			RuleFor(x => x.Name).Length(1,65)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");

			RuleFor(x => x.AcademicYearId)
			.GreaterThan(-1)
			.WithMessage("AcademicYearId should be greater than - 1");

			RuleFor(x => x.Description).Length(000,000)
			.When(x=>x.Description != null)
			.WithMessage("Description  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Description should not be empty");


		}
	}
}
