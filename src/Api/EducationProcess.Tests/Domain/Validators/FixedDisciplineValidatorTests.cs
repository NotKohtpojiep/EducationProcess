using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class FixedDisciplineValidatorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("         ", "      ")]
        [InlineData(null, "")]
        [InlineData("", null)]

        public void Validate_FixedDisciplineIsNotValid_ShouldHaveErrors(string commentByFixingEmployee, string commentByEmployeeFixer)
        {
            // arrange
            FixedDiscipline FixedDiscipline = new FixedDiscipline()
            {
                FixedDisciplineId = 0,
                CommentByFixingEmployee = commentByFixingEmployee,
                CommentByEmployeeFixer = commentByEmployeeFixer

            };

            FixedDisciplineValidator validator = new FixedDisciplineValidator();

            // act
            var result = validator.Validate(FixedDiscipline);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("sdf", "vmntgy")]
        [InlineData("sgwsegw", null)]
        [InlineData(null, "clkm")]

        public void Validate_FixedDisciplineIsValid_ShouldHaveNoErrors(string commentByFixingEmployee, string commentByEmployeeFixer)
        {
            // arrange
            FixedDiscipline FixedDiscipline = new FixedDiscipline()
            {
                FixedDisciplineId = 0,
                CommentByFixingEmployee = commentByFixingEmployee,
                CommentByEmployeeFixer = commentByEmployeeFixer

            };

            FixedDisciplineValidator validator = new FixedDisciplineValidator();

            // act
            var result = validator.Validate(FixedDiscipline);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
