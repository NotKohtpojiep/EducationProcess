using System.Threading.Tasks;
using EducationProcess.Domain.Models;
using EducationProcess.Domain.Validators;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class AudienceTypeValidatorTests
    {
        public AudienceTypeValidatorTests()
        {

        }

        [Theory]
        [InlineData("", "2020")]
        [InlineData("1000", "")]
        public void Validate_AudienceTypeIsNotValid_ShouldHaveErrors(string name, string description)
        {
            // arrange
            AudienceType audienceType = new AudienceType()
            {
                AudienceTypeId = 0,
                Name = name,
                Description = description
            };

            AudienceTypeValidator validator = new AudienceTypeValidator();

            // act
            var result = validator.Validate(audienceType);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("2021", "2020")]
        [InlineData("1000", null)]
        public void Validate_AudienceTypeIsValid_ShouldNotHaveErrors(string name, string description)
        {
            // arrange
            AudienceType audienceType = new AudienceType()
            {
                AudienceTypeId = 0,
                Name = name,
                Description = description
            };

            AudienceTypeValidator validator = new AudienceTypeValidator();

            // act
            var result = validator.Validate(audienceType);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}