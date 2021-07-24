using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class EmployeeCathedraValidator : AbstractValidator<EmployeeCathedra>
	{
		public EmployeeCathedraValidator()
		{
			RuleFor(x => x.EmployeeId)
			.GreaterThan(-1)
			.WithMessage("EmployeeId should be greater than - 1");

			RuleFor(x => x.CathedraId)
			.GreaterThan(-1)
			.WithMessage("CathedraId should be greater than - 1");


		}
	}
}
