using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class ReceivedSpecialtyValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("khjrglhkrptkhrkjpfgkjhproikthporjtpohjmrpobkrpkbdhbdkfghlkhdlndlbsdmnkseowjefhjvsnsdfmflaajifwqpqwrhj")]
        public async Task Validate_ReceivedSpecialtyIsNotValid_ShouldHaveErrors(string qualification)
        {
            // arrange
            ReceivedSpecialty ReceivedSpecialty = new ReceivedSpecialty()
            {
                ReceivedSpecialtyId = 0,
                Qualification = qualification,
            };

            ReceivedSpecialtyValidator validator = new ReceivedSpecialtyValidator();

            // act
            var result = validator.Validate(ReceivedSpecialty);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("khjrglhkrptkhrkjpfgkjhpr")]
        public async Task Validate_ReceivedSpecialtyIsValid_ShouldHaveNoErrors(string qualification)
        {
            // arrange
            ReceivedSpecialty ReceivedSpecialty = new ReceivedSpecialty()
            {
                ReceivedSpecialtyId = 0,
                Qualification = qualification,
            };

            ReceivedSpecialtyValidator validator = new ReceivedSpecialtyValidator();

            // act
            var result = validator.Validate(ReceivedSpecialty);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
