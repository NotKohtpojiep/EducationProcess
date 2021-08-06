using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 10)
                    .WithMessage("Name  length should contain from 1 to 10 symbols");

            RuleFor(x => x.CourseNumber)
                .GreaterThanOrEqualTo((byte)1)
                    .WithMessage("CourseNumber should be greater than - 1")
                .LessThan((byte)10)
                    .WithMessage("CourseNumber should be less than - 10");
        }
    }
}