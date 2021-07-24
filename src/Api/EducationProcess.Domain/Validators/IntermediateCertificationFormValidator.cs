using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class IntermediateCertificationFormValidator : AbstractValidator<IntermediateCertificationForm>
	{
		public IntermediateCertificationFormValidator()
		{
			RuleFor(x => x.CertificationFormId)
			.GreaterThan(-1)
			.WithMessage("CertificationFormId should be greater than - 1");

			RuleFor(x => x.Name).Length(000,000)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");


		}
	}
}
