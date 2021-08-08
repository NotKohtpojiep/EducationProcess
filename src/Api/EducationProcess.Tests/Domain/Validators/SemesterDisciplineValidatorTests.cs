using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class SemesterDisciplineValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("ptprglhkrptkhrkjpfgkjhproikthporjtpohjmrpobkrpkbdhbdkfghlkhdlndlbsdmnkseowjefhjvsnsdfmflaajifwqpqwrhjfpdsjgejpoigpslkgpqewetigjgneknrkgeioruqwrqnensdjlskjgejtowiefrsjkhdkfghsidufiquwrbmzxczmvbhvbsgdfakwroqwrpqrqposdgnkvbisgefwherwygeuwuwuwuwuwuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu")]
        public void Validate_SemesterDisciplineIsNotValid_ShouldHaveErrors(string description)
        {
            // arrange
            SemesterDiscipline SemesterDiscipline = new SemesterDiscipline()
            {
                SemesterDisciplineId = 0,
                Description = description,
            };

            SemesterDisciplineValidator validator = new SemesterDisciplineValidator();

            // act
            var result = validator.Validate(SemesterDiscipline);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("ehetenattayo")]
        public void Validate_SemesterDisciplineIsValid_ShouldHaveNoErrors(string description)
        {
            // arrange
            SemesterDiscipline SemesterDiscipline = new SemesterDiscipline()
            {
                SemesterDisciplineId = 0,
                Description = description,
            };

            SemesterDisciplineValidator validator = new SemesterDisciplineValidator();

            // act
            var result = validator.Validate(SemesterDiscipline);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
