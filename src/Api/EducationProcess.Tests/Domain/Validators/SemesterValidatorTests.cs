using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class SemesterValidatorTests
    {
        [Theory]
        [InlineData(32, 101)]
        [InlineData(13, 103)]
        [InlineData(133, 100)]
        public void Validate_SemesterIsNotValid_ShouldHaveErrors(byte number, byte weeksCount)
        {
            // arrange
            Semester Semester = new Semester()
            {
                SemesterId = 0,
                Number = number,
                WeeksCount = weeksCount
            };

            SemesterValidator validator = new SemesterValidator();

            // act
            var result = validator.Validate(Semester);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData(12, 60)]
        public void Validate_SemesterIsValid_ShouldHaveNoErrors(byte number, byte weeksCount)
        {
            // arrange
            Semester Semester = new Semester()
            {
                SemesterId = 0,
                Number = number,
                WeeksCount = weeksCount
            };

            SemesterValidator validator = new SemesterValidator();

            // act
            var result = validator.Validate(Semester);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
