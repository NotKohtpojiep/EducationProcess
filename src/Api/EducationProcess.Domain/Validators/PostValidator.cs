using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
	public class PostValidator : AbstractValidator<Post>
	{
		public PostValidator()
		{
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1,75)
                    .WithMessage("Name  length should contain from 1 to 75 symbols");
        }
	}
}