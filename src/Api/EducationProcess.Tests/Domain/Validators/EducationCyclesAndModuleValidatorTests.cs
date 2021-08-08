using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
     public class EducationCyclesAndModuleValidatorTests
    {
        [Theory]
        [InlineData("", "", null)]
        [InlineData("         ", "      ", "   ")]
        [InlineData("rewtyeryryewyeyreywery", "rewty", null)]
        [InlineData("", "rewty", null)]
        [InlineData("rewty", "", null)]

        public void Validate_EducationCyclesAndModuleIsNotValid_ShouldHaveErrors(string educationCycleIndex, string name, string description)
        {
            // arrange
            EducationCyclesAndModule EducationCyclesAndModule = new EducationCyclesAndModule()
            {
                EducationCycleId = 0,
                EducationCycleIndex = educationCycleIndex,
                Name = name,
                Description = description
            };

            EducationCyclesAndModuleValidator validator = new EducationCyclesAndModuleValidator();

            // act
            var result = validator.Validate(EducationCyclesAndModule);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("raw", "low", null)]
        [InlineData("high", "youth", "lalala")]
        public void Validate_EducationCyclesAndModuleIsValid_ShouldHaveNoErrors(string educationCycleIndex, string name, string description)
        {
            // arrange
            EducationCyclesAndModule EducationCyclesAndModule = new EducationCyclesAndModule()
            {
                EducationCycleId = 0,
                EducationCycleIndex = educationCycleIndex,
                Name = name,
                Description = description
            };

            EducationCyclesAndModuleValidator validator = new EducationCyclesAndModuleValidator();

            // act
            var result = validator.Validate(EducationCyclesAndModule);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
