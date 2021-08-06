using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
	public class EmployeeValidator : AbstractValidator<Employee>
	{
		public EmployeeValidator()
		{
            RuleFor(x => x.Firstname)
                .NotEmpty()
                    .WithMessage("Firstname should not be empty")
                .Length(1,75)
                    .WithMessage("Firstname  length should contain from 1 to 75 symbols");

			RuleFor(x => x.Lastname)
                .NotEmpty()
                    .WithMessage("Lastname should not be empty")
                .Length(1,75)
                    .WithMessage("Lastname  length should contain from 1 to 75 symbols");

            RuleFor(x => x.Middlename)
                .Length(1, 75).When(x => x.Middlename != null)
                    .WithMessage("Middlename  length should contain from 1 to 75 symbols");
        }
	}
}