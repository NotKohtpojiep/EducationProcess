using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class FsesCategoryValidator : AbstractValidator<FsesCategory>
	{
		public FsesCategoryValidator()
		{
			RuleFor(x => x.FsesCategoryId)
			.GreaterThan(-1)
			.WithMessage("FsesCategoryId should be greater than - 1");

			RuleFor(x => x.Number)
			.LessThan((short)32000)
			.WithMessage("Number should be greater than - 1");

			RuleFor(x => x.Name).Length(000,000)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");

			RuleFor(x => x.FsesId)
			.GreaterThan(-1)
			.WithMessage("FsesId should be greater than - 1");


		}
	}
}
