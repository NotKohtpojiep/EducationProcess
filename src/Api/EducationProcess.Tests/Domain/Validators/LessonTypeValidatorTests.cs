using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class LessonTypeValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        [InlineData("hbbhwhslsfoeirutyrpovnvcmqkdfrpqmcvbfuiquuuuhuumcnbqiswefoojfhaepqxmcnskdfjesdjfnoirernbieowvnsjkalqqfqbbbdfjgkervnsmsdhfw")]

        public void Validate_LessonTypeIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            LessonType LessonType = new LessonType()
            {
                LessonTypeId = 0,
                Name = name,
            };

            LessonTypeValidator validator = new LessonTypeValidator();

            // act
            var result = validator.Validate(LessonType);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("dfghet")]
        public void Validate_LessonTypeIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            LessonType LessonType = new LessonType()
            {
                LessonTypeId = 0,
                Name = name,
            };

            LessonTypeValidator validator = new LessonTypeValidator();

            // act
            var result = validator.Validate(LessonType);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
