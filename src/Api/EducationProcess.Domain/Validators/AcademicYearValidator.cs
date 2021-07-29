using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class AcademicYearValidator : AbstractValidator<AcademicYear>
    {
        public AcademicYearValidator()
        {
            RuleFor(x => x.BeginingYear)
                .GreaterThan((ushort)2020)
                    .WithMessage("Begining year should be greater than 2020")
                .LessThan((ushort)2050)
                    .WithMessage("Begining year should be less than 2050")
                .LessThanOrEqualTo(x => x.EndingYear)
                    .WithMessage(x => $"Begining year should be greater or equal {x.EndingYear}");

            RuleFor(x => x.EndingYear)
                .GreaterThan((ushort)2020)
                    .WithMessage("Ending year should be greater than 2020")
                .LessThan((ushort)2050)
                    .WithMessage("Begining year should be less than 2050")
                .GreaterThanOrEqualTo(x => x.BeginingYear)
                    .WithMessage(x => $"Ending year should be greater or equal {x.BeginingYear}");
        }
    }
}