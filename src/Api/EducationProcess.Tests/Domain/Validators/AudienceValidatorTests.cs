using EducationProcess.Domain.Models;
using EducationProcess.Domain.Validators;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class AudienceValidatorTests
    {
        [Theory]
        [InlineData("", "2020")]
        [InlineData(null, "")]
        [InlineData("", "202020")]
        [InlineData(null, "         ")]
        [InlineData(null, null)]
        [InlineData("Вася", "")]
        public async Task Validate_AudienceIsNotValid_ShouldHaveErrors(string name, string number)
        {
            // arrange
            Audience Audience = new Audience()
            {
                AudienceId = 0,
                Name = name,
                Number = number
            };

            AudienceValidator validator = new AudienceValidator();

            // act
            var result = validator.Validate(Audience);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
        [Theory]
        [InlineData(null, "29Б")]
        [InlineData("ворона", "29А")]
        [InlineData(null, "202")]
        public async Task Validate_AudienceIsValid_ShouldHaveNoErrors(string name, string number)
        {
            // arrange
            Audience Audience = new Audience()
            {
                AudienceId = 0,
                Name = name,
                Number = number
            };

            AudienceValidator validator = new AudienceValidator();

            // act
            var result = validator.Validate(Audience);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }

}
