using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class FederalStateEducationalStandardValidator : AbstractValidator<FederalStateEducationalStandard>
	{
		public FederalStateEducationalStandardValidator()
		{
			RuleFor(x => x.FsesId)
			.GreaterThan(-1)
			.WithMessage("FsesId should be greater than - 1");

			RuleFor(x => x.Number)
			.LessThan((short)32000)
			.WithMessage("Number should be greater than - 1");

			RuleFor(x => x.Name).Length(1,1)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 1 to 1 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");


		}
	}
}
