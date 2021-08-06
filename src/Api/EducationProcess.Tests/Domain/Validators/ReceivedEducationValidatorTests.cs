using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class ReceivedEducationValidatorTests
    {
        [Theory]
        [InlineData(101)]
        public async Task Validate_ReceivedEducationIsNotValid_ShouldHaveErrors(ushort studyPeriodMonths)
        {
            // arrange
            ReceivedEducation ReceivedEducation = new ReceivedEducation()
            {
                ReceivedEducationId = 0,
                StudyPeriodMonths = studyPeriodMonths,
            };

            ReceivedEducationValidator validator = new ReceivedEducationValidator();

            // act
            var result = validator.Validate(ReceivedEducation);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData(45)]
        public async Task Validate_ReceivedEducationIsValid_ShouldHaveNoErrors(ushort studyPeriodMonths)
        {
            // arrange
            ReceivedEducation ReceivedEducation = new ReceivedEducation()
            {
                ReceivedEducationId = 0,
                StudyPeriodMonths = studyPeriodMonths,
            };

            ReceivedEducationValidator validator = new ReceivedEducationValidator();

            // act
            var result = validator.Validate(ReceivedEducation);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
