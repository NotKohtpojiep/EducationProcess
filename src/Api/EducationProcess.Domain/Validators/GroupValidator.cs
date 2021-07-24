using EducationProcess.Domain.Models;
using FluentValidation;
namespace EducationProcess.Domain.Validators
{
	class GroupValidator : AbstractValidator<Group>
	{
		public GroupValidator()
		{
			RuleFor(x => x.GroupId)
			.GreaterThan(-1)
			.WithMessage("GroupId should be greater than - 1");

			RuleFor(x => x.Name).Length(1,10)
			.When(x=>x.Name != null)
			.WithMessage("Name  length should contain from 1 to 10 symbols")
			.NotEmpty()
			.WithMessage("Name should not be empty");

			RuleFor(x => x.CourseNumber)
			.LessThan((byte)127)
			.WithMessage("CourseNumber should be greater than - 1");

			RuleFor(x => x.CuratorId)
			.GreaterThan(-1)
			.WithMessage("CuratorId should be greater than - 1");

			RuleFor(x => x.ReceivedEducationId)
			.GreaterThan(-1)
			.WithMessage("ReceivedEducationId should be greater than - 1");

			RuleFor(x => x.EducationPlanId)
			.GreaterThan(-1)
			.When(x=>x.EducationPlanId != null)
			.WithMessage("EducationPlanId should be greater than - 1");


			RuleFor(x => x.ReceiptYear)
			.LessThan((short)32000)
			.WithMessage("ReceiptYear should be greater than - 1");


		}
	}
}
