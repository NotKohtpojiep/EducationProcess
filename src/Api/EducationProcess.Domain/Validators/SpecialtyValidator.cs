using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class SpecialtyValidator : AbstractValidator<Specialty>
	{
		public SpecialtyValidator()
		{
			RuleFor(x => x.SpecialtieId)
			.GreaterThan(-1)
			.WithMessage("SpecialtieId should be greater than - 1");

			RuleFor(x => x.SpecialtieCode).Length(1,10)
			.When(x=>x.SpecialtieCode != null)
			.WithMessage("SpecialtieCode  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("SpecialtieCode should not be empty");

			RuleFor(x => x.ImplementedSpecialtyName).Length(0,100)
			.When(x=>x.ImplementedSpecialtyName != null)
			.WithMessage("ImplementedSpecialtyName  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("ImplementedSpecialtyName should not be empty");

			RuleFor(x => x.Abbreviation).Length(0, 10)
			.When(x => x.Abbreviation != null)
			.WithMessage("Abbreviation  length should contain from 0 to 10 symbols");


		}
	}
}
