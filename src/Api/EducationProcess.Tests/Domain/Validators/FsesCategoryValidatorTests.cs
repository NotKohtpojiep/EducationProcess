using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class FsesCategoryValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        //this line contains 82 symbols
        [InlineData("Dfjgkdhbbhwhslsfoeirutyrpovnvcmqkdfrpqmcvbfuiquuuuhuumcnbqiswefoojfhaepqxmcnskdfje")]

        public async Task Validate_FsesCategoryIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            FsesCategory FsesCategory = new FsesCategory()
            {
                FsesCategoryId = 0,
                Name = name,
            };

            FsesCategoryValidator validator = new FsesCategoryValidator();

            // act
            var result = validator.Validate(FsesCategory);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("sdjobxlms")]
        public async Task Validate_FsesCategoryIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            FsesCategory FsesCategory = new FsesCategory()
            {
                FsesCategoryId = 0,
                Name = name,
            };

            FsesCategoryValidator validator = new FsesCategoryValidator();

            // act
            var result = validator.Validate(FsesCategory);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
