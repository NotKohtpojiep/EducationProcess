using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class FederalStateEducationalStandardValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        //в строке 137 символов
        [InlineData("Fdkdkjfhgbeierjbejnfeijnfi3eurfhoeijvoeijvoerjiiojgoergergldfkjneoowpwiriririruthgtgjslalasjdnbfwejrkbvkejhgekjnekmvenpweggvyuwubcmakabqq")]

        public async Task Validate_FederalStateEducationalStandardIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            FederalStateEducationalStandard FederalStateEducationalStandard = new FederalStateEducationalStandard()
            {
                FsesId = 0,
                Name = name,

            };

            FederalStateEducationalStandardValidator validator = new FederalStateEducationalStandardValidator();

            // act
            var result = validator.Validate(FederalStateEducationalStandard);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("sdfwg")]
        public async Task Validate_FederalStateEducationalStandardIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            FederalStateEducationalStandard FederalStateEducationalStandard = new FederalStateEducationalStandard()
            {
                FsesId = 0,
                Name = name,

            };

            FederalStateEducationalStandardValidator validator = new FederalStateEducationalStandardValidator();

            // act
            var result = validator.Validate(FederalStateEducationalStandard);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
