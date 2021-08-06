using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class EducationLevelValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        //в строке данной ниже около 102-103 символов
        [InlineData("dkfjguimprjfghtklanbdhfgjaqprmvnqiowieuryzpamdnfbydddddddddddddddddddddddddddjhaaaaaaapppqoiuyuiopaoooo")]

        public async Task Validate_EducationLevelIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            EducationLevel EducationLevel = new EducationLevel()
            {
                EducationLevelId = 0,
                Name = name,
            };

            EducationLevelValidator validator = new EducationLevelValidator();

            // act
            var result = validator.Validate(EducationLevel);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("dkfh")]
        public async Task Validate_EducationLevelIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            EducationLevel EducationLevel = new EducationLevel()
            {
                EducationLevelId = 0,
                Name = name,
            };

            EducationLevelValidator validator = new EducationLevelValidator();

            // act
            var result = validator.Validate(EducationLevel);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
