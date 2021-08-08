using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class EducationFormValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        //в строке данной ниже около 102-103 символов
        [InlineData("dkfjguimprjfghtklanbdhfgjaqprmvnqiowieuryzpamdnfbydddddddddddddddddddddddddddjhaaaaaaapppqoiuyuiopaoooo")]

        public void Validate_EducationFormIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            EducationForm EducationForm = new EducationForm()
            {
                EducationFormId = 0,
                Name = name,
            };

            EducationFormValidator validator = new EducationFormValidator();

            // act
            var result = validator.Validate(EducationForm);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("dfgea")]
        public void Validate_EducationFormIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            EducationForm EducationForm = new EducationForm()
            {
                EducationFormId = 0,
                Name = name,
            };

            EducationFormValidator validator = new EducationFormValidator();

            // act
            var result = validator.Validate(EducationForm);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
