using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
	public class ScheduleDisciplineValidator : AbstractValidator<ScheduleDiscipline>
	{
		public ScheduleDisciplineValidator()
		{
			RuleFor(x => x.AudienceId)
					.GreaterThanOrEqualTo(0)
						.WithMessage("AudienceId should be greater or equal 0");
			RuleFor(x => x.CreatedByEmployeeId)
				.GreaterThanOrEqualTo(0)
					.WithMessage("AudienceId should be greater or equal 0");
			RuleFor(x => x.FixedDisciplineId)
				.GreaterThanOrEqualTo(0)
					.WithMessage("AudienceId should be greater or equal 0");
			RuleFor(x => x.ModifiedByEmployeeId)
				.GreaterThanOrEqualTo(0)
					.WithMessage("AudienceId should be greater or equal 0");
			RuleFor(x => x.ScheduleDisciplineId)
				.GreaterThanOrEqualTo(0)
					.WithMessage("AudienceId should be greater or equal 0");

			RuleFor(x => x.Date.Year)
				.GreaterThan(2000)
					.WithMessage("Date (year) should be greater than 2000")
				.LessThan(2050)
					.WithMessage("Date (year) should be less than 2050");
			RuleFor(x => x.CreatedAt.Year)
				.GreaterThan(2000)
					.WithMessage("CreatedAt (year) should be greater than 2000")
				.LessThan(2050)
					.WithMessage("CreatedAt (year) should be less than 2050");
			RuleFor(x => x.ModifiedAt.Year)
				.GreaterThan(2000)
					.WithMessage("ModifiedAt (year) should be greater than 2000")
				.LessThan(2050)
					.WithMessage("ModifiedAt (year) should be less than 2050");

			RuleFor(x => x.PairNumber)
				.GreaterThanOrEqualTo(1)
					.WithMessage("PairNumber should be greater or equal 1")
				.LessThanOrEqualTo(6)
					.WithMessage("PairNumber should be less or equal 6");
		}
	}
}