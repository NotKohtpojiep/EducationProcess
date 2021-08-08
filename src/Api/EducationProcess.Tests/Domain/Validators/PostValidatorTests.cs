using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class PostValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        [InlineData("uuuhuumcnbqiswefoojfhaepqxmcnskdfjesdjfnoirernbieowvnsjkalqqfqbbbdfjgkervnsmsdhfw")]

        public void Validate_PostIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            Post Post = new Post()
            {
                PostId = 0,
                Name = name,
            };

            PostValidator validator = new PostValidator();

            // act
            var result = validator.Validate(Post);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("fonjo")]
        public void Validate_PostIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            Post Post = new Post()
            {
                PostId = 0,
                Name = name,
            };

            PostValidator validator = new PostValidator();

            // act
            var result = validator.Validate(Post);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
