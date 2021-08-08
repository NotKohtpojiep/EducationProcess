using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class EducationPlanValidatorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("         ", "        ")]
        //в name 66-67 символов, в description 102-103 символов
        [InlineData("dkfjlmfhgyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy", "dkfjguimprjfghtklanbdhfgjaqprmvnqiowieuryzpamdnfbydddddddddddddddddddddddddddjhaaaaaaapppqoiuyuiopaoooo")]
        [InlineData("ывы", "")]
        [InlineData("", null)]

        public void Validate_EducationPlanIsNotValid_ShouldHaveErrors(string name, string description)
        {
            // arrange
            EducationPlan EducationPlan = new EducationPlan()
            {
                EducationPlanId = 0,
                Name = name,
                Description = description,
            };

            EducationPlanValidator validator = new EducationPlanValidator();

            // act
            var result = validator.Validate(EducationPlan);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("dfjgh", "fdger")]
        [InlineData("dfjgh", null)]
        public void Validate_EducationPlanIsValid_ShouldHaveNoErrors(string name, string description)
        {
            // arrange
            EducationPlan EducationPlan = new EducationPlan()
            {
                EducationPlanId = 0,
                Name = name,
                Description = description,
            };

            EducationPlanValidator validator = new EducationPlanValidator();

            // act
            var result = validator.Validate(EducationPlan);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
