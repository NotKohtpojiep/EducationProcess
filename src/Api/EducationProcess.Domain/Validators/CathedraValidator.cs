using EducationProcess.Domain.Models;
using FluentValidation;

namespace EducationProcess.Domain.Validators
{
    public class CathedraValidator : AbstractValidator<Cathedra>
    {
        public CathedraValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                    .WithMessage("Name should not be empty")
                .Length(1, 75)
                    .WithMessage("Name should contain from 1 to 75 symbols");

            RuleFor(x=>x.NameAbbreviation)
                .Length(1,10).When(x => x.NameAbbreviation != null)
                    .WithMessage("Name abbreviation should contain from 1 to 10 symbols");

            RuleFor(x=>x.Description)
                .Length(1,300).When(x => x.Description != null)
                    .WithMessage("Name abbreviation should contain from 1 to 300 symbols");
        }
    }
}