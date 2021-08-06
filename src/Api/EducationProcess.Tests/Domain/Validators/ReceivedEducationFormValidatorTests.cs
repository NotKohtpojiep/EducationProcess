using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class ReceivedEducationFormValidatorTests
    {
        [Theory]
        [InlineData("")]
        public async Task Validate_ReceivedEducationFormIsNotValid_ShouldHaveErrors(string additionalInfo)
        {
            // arrange
            ReceivedEducationForm ReceivedEducationForm = new ReceivedEducationForm()
            {
                ReceivedEducationFormId = 0,
                AdditionalInfo = additionalInfo,
            };

            ReceivedEducationFormValidator validator = new ReceivedEducationFormValidator();

            // act
            var result = validator.Validate(ReceivedEducationForm);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("sjkfhv")]
        [InlineData(null)]
        public async Task Validate_ReceivedEducationFormIsValid_ShouldHaveNoErrors(string additionalInfo)
        {
            // arrange
            ReceivedEducationForm ReceivedEducationForm = new ReceivedEducationForm()
            {
                ReceivedEducationFormId = 0,
                AdditionalInfo = additionalInfo,
            };

            ReceivedEducationFormValidator validator = new ReceivedEducationFormValidator();

            // act
            var result = validator.Validate(ReceivedEducationForm);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
