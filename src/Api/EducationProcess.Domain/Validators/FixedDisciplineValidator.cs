using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class FixedDisciplineValidator : AbstractValidator<FixedDiscipline>
    {
        public FixedDisciplineValidator()
        {
            RuleFor(x => x.CommentByFixingEmployee)
                .Length(1, 300).When(x => x.CommentByFixingEmployee != null)
                    .WithMessage("CommentByFixingEmployee  length should contain from 1 to 300 symbols");

            RuleFor(x => x.CommentByFixerEmployee)
                .Length(1, 300).When(x => x.CommentByFixerEmployee != null)
                    .WithMessage("CommentByFixerEmployee  length should contain from 1 to 300 symbols");
        }
    }
}