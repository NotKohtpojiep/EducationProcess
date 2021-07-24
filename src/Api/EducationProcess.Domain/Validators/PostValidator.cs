using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class PostValidator : AbstractValidator<Post>
	{
		public PostValidator()
		{
			RuleFor(x => x.PostId)
			.GreaterThan(-1)
			.WithMessage("PostId should be greater than - 1");

			RuleFor(x => x.Name).Length(0,75)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");


		}
	}
}
