using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class FixedDisciplineValidator : AbstractValidator<FixedDiscipline>
    {
        public FixedDisciplineValidator()
        {
            RuleFor(x => x.CommentByFixingEmployee)
                .NotEmpty().Length(1, 300).When(x => x.CommentByFixingEmployee != null)
                    .WithMessage("CommentByFixingEmployee  length should contain from 1 to 300 symbols");

            RuleFor(x => x.CommentByEmployeeFixer)
                .NotEmpty().Length(1, 300).When(x => x.CommentByEmployeeFixer != null)
                    .WithMessage("CommentByEmployeeFixer  length should contain from 1 to 300 symbols");
        }
    }
}