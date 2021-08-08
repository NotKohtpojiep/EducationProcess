using EducationProcess.Domain.Models;
using EducationProcess.Domain.Validators;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class DisciplineValidatorTests
    {
        [Theory]
        [InlineData("", "", null)]
        [InlineData("         ", "      ", "   ")]
        [InlineData("dfg", null, null)]

        public void Validate_DisciplineIsNotValid_ShouldHaveErrors(string disciplineIndex, string name, string description)
        {
            // arrange
            Discipline Discipline = new Discipline()
            {
                DisciplineId = 0,
                DisciplineIndex = disciplineIndex,
                Name = name,
                Description = description
            };

            DisciplineValidator validator = new DisciplineValidator();

            // act
            var result = validator.Validate(Discipline);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
        [Theory]
        [InlineData("sdg", "gsgfg", "wgwg")]
        [InlineData("dfg", "fhrh", null)]


        public void Validate_DisciplineIsValid_ShouldHaveNoErrors(string disciplineIndex, string name, string description)
        {
            // arrange
            Discipline Discipline = new Discipline()
            {
                DisciplineId = 0,
                DisciplineIndex = disciplineIndex,
                Name = name,
                Description = description
            };

            DisciplineValidator validator = new DisciplineValidator();

            // act
            var result = validator.Validate(Discipline);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
