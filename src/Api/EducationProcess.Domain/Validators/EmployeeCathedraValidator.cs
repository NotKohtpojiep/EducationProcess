using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
	public class EmployeeCathedraValidator : AbstractValidator<EmployeeCathedra>
	{
		public EmployeeCathedraValidator()
		{
			RuleFor(x=> x.CathedraId)
				.GreaterThanOrEqualTo(0)
					.WithMessage("CathedraId should be greater or equal 0");
			RuleFor(x=> x.EmployeeId)
				.GreaterThanOrEqualTo(0)
					.WithMessage("EmployeeId should be greater or equal 0");
		}
	}
}