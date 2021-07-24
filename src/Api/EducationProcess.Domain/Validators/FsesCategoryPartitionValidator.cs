using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class FsesCategoryPartitionValidator : AbstractValidator<FsesCategoryPartition>
	{
		public FsesCategoryPartitionValidator()
		{
			RuleFor(x => x.FsesCategoryPatitionId)
			.GreaterThan(-1)
			.WithMessage("FsesCategoryPatitionId should be greater than - 1");

			RuleFor(x => x.ThirdPathNumber)
			.LessThan((short)32000)
			.When(x=>x.ThirdPathNumber != null)
			.WithMessage("ThirdPathNumber should be greater than - 1");


			RuleFor(x => x.Name).Length(000,000)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");

			RuleFor(x => x.NameAbbreviation).Length(000,000)
			.When(x=>x.NameAbbreviation != null)
			.WithMessage("NameAbbreviation  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("NameAbbreviation should not be empty");

			RuleFor(x => x.FsesCategoryId)
			.GreaterThan(-1)
			.WithMessage("FsesCategoryId should be greater than - 1");


		}
	}
}
