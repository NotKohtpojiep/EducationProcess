using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class EmployeeValidatorTests
    {
        [Theory]
        [InlineData("", "","")]
        [InlineData("         ", "        ","           ")]
        [InlineData("sdfgwg", "", "")]
        [InlineData("", "sdgwe", "")]
        [InlineData("", "", null)]
        [InlineData("sdbbb", "", null)]
        [InlineData("", "sdfw", null)]

        public async Task Validate_EmployeeIsNotValid_ShouldHaveErrors(string firstname, string lastname, string middlename)
        {
            // arrange
            Employee Employee = new Employee()
            {
                EmployeeId = 0,
                Firstname = firstname,
                Lastname = lastname,
                Middlename = middlename
            };

            EmployeeValidator validator = new EmployeeValidator();

            // act
            var result = validator.Validate(Employee);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("sdbbb", "fgdfg", null)]
        [InlineData("ererge", "sdfw", "lkjg")]
        public async Task Validate_EmployeeIsValid_ShouldHaveNoErrors(string firstname, string lastname, string middlename)
        {
            // arrange
            Employee Employee = new Employee()
            {
                EmployeeId = 0,
                Firstname = firstname,
                Lastname = lastname,
                Middlename = middlename
            };

            EmployeeValidator validator = new EmployeeValidator();

            // act
            var result = validator.Validate(Employee);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
