using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class EmployeeValidator : AbstractValidator<Employee>
	{
		public EmployeeValidator()
		{
			RuleFor(x => x.EmployeeId)
			.GreaterThan(-1)
			.WithMessage("EmployeeId should be greater than - 1");

			RuleFor(x => x.Firstname).Length(1,75)
			.When(x=>x.Firstname != null)
			.WithMessage("Firstname  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Firstname should not be empty");

			RuleFor(x => x.Lastname).Length(1,75)
			.When(x=>x.Lastname != null)
			.WithMessage("Lastname  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Lastname should not be empty");

			RuleFor(x => x.Middlename).Length(0,75)
			.WithMessage("Middlename  length should contain from 000 to 000 symbols")
			.WithMessage("Middlename should not be empty");

			RuleFor(x => x.PostId)
			.GreaterThan(-1)
			.WithMessage("PostId should be greater than - 1");


		}
	}
}
