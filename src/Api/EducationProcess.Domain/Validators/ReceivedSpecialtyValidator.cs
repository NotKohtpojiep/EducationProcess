using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class ReceivedSpecialtyValidator : AbstractValidator<ReceivedSpecialty>
	{
		public ReceivedSpecialtyValidator()
		{
			RuleFor(x => x.ReceivedSpecialtyId)
			.GreaterThan(-1)
			.WithMessage("ReceivedSpecialtyId should be greater than - 1");

			RuleFor(x => x.FsesCategoryPatitionId)
			.GreaterThan(-1)
			.WithMessage("FsesCategoryPatitionId should be greater than - 1");

			RuleFor(x => x.Qualification).Length(0, 100)
			.When(x => x.Qualification != null)
			.WithMessage("Qualification  length should contain from 000 to 000 symbols");


		}
	}
}
