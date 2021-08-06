using EducationProcess.Domain.Models;
using EducationProcess.Domain.Validators;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class CathedraValidatorTests
    {

        [Theory]
        [InlineData("", "", "")]
        [InlineData("b", "eirotpdgjdljbmcmbldd", "")]
        [InlineData("var", "", null)]
        [InlineData(null, null, null)]
        [InlineData("     ", "    ", "   ")]
        [InlineData("", null, "bruh")]

        public async Task Validate_CathedraIsNotValid_ShouldHaveErrors(string name, string nameAbbrevation, string description)
        {
            // arrange
            Cathedra Cathedra = new Cathedra()
            {
                CathedraId = 0,
                Name = name,
                NameAbbreviation = nameAbbrevation,
                Description = description
            };

            CathedraValidator validator = new CathedraValidator();

            // act
            var result = validator.Validate(Cathedra);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("b", "eirotpdg", "boom")]
        [InlineData("var", "202020", null)]
        [InlineData("var", null, "2020")]

        public async Task Validate_CathedraIsValid_ShouldHaveNoErrors(string name, string nameAbbrevation, string description)
        {
            // arrange
            Cathedra Cathedra = new Cathedra()
            {
                CathedraId = 0,
                Name = name,
                NameAbbreviation = nameAbbrevation,
                Description = description
            };

            CathedraValidator validator = new CathedraValidator();

            // act
            var result = validator.Validate(Cathedra);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
