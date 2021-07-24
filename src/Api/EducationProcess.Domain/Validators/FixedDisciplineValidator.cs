using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class FixedDisciplineValidator : AbstractValidator<FixedDiscipline>
	{
		public FixedDisciplineValidator()
		{
			RuleFor(x => x.FixedDisciplineId)
			.GreaterThan(-1)
			.WithMessage("FixedDisciplineId should be greater than - 1");

			RuleFor(x => x.FixingEmployeeId)
			.GreaterThan(-1)
			.WithMessage("FixingEmployeeId should be greater than - 1");

			RuleFor(x => x.SemesterDisciplineId)
			.GreaterThan(-1)
			.WithMessage("SemesterDisciplineId should be greater than - 1");

			RuleFor(x => x.GroupId)
			.GreaterThan(-1)
			.WithMessage("GroupId should be greater than - 1");

			RuleFor(x => x.FixerEmployeeId)
			.GreaterThan(-1)
			.WithMessage("FixerEmployeeId should be greater than - 1");

			RuleFor(x => x.CommentByFixingEmployee).Length(000, 000)
			.When(x => x.CommentByFixingEmployee != null)
			.WithMessage("CommentByFixingEmployee  length should contain from 000 to 000 symbols");

			RuleFor(x => x.CommentByFixerEmployee).Length(000,000)
			.When(x=>x.CommentByFixerEmployee != null)
			.WithMessage("CommentByFixerEmployee  length should contain from 000 to 000 symbols")
			.NotEmpty()
			.WithMessage("CommentByFixerEmployee should not be empty");


		}
	}
}
