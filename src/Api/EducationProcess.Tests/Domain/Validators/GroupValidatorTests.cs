using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class GroupValidatorTests
    {
        [Theory]
        [InlineData("",1)]
        [InlineData("         ", 4)]
        [InlineData("Dfjgkdhbbhwhslsfoeirutyrpovnvcmqkdfrpqmcvbfuiquuuuhuumcnbqiswefoojfhaepqxmcnskdfje", 3)]
        [InlineData("Dfjgkd", 13)]

        public void Validate_GroupIsNotValid_ShouldHaveErrors(string name, byte courseNumber)
        {
            // arrange
            Group Group = new Group()
            {
                GroupId = 0,
                Name = name,
                CourseNumber = courseNumber
            };

            GroupValidator validator = new GroupValidator();

            // act
            var result = validator.Validate(Group);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("PB", 1)]
        public void Validate_GroupIsValid_ShouldHaveNoErrors(string name, byte courseNumber)
        {
            // arrange
            Group Group = new Group()
            {
                GroupId = 0,
                Name = name,
                CourseNumber = courseNumber
            };

            GroupValidator validator = new GroupValidator();

            // act
            var result = validator.Validate(Group);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
