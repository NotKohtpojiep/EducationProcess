using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class FsesCategoryPartitionValidator : AbstractValidator<FsesCategoryPartition>
    {
        public FsesCategoryPartitionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 120)
                    .WithMessage("Name  length should contain from 1 to 120 symbols");

            RuleFor(x => x.NameAbbreviation)
                .NotEmpty()
                    .WithMessage("NameAbbreviation should not be empty")
                .Length(1, 75)
                    .WithMessage("NameAbbreviation  length should contain from 1 to 75 symbols");
        }
    }
}