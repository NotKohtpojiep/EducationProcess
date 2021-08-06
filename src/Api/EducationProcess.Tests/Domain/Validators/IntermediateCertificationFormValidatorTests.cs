using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class IntermediateCertificationFormValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("         ")]
        [InlineData("Dfjgkdhbbhwhslsfoeirutyrpovnvcmqkdfrpqmcvbfuiquuuuhuumcnbqiswefoojfhaepqxmcnskdfjesdjfnoirernbieowvnsjkalqqfqbbbdfjgkervnsmsdhfw")]

        public async Task Validate_IntermediateCertificationFormIsNotValid_ShouldHaveErrors(string name)
        {
            // arrange
            IntermediateCertificationForm IntermediateCertificationForm = new IntermediateCertificationForm()
            {
                CertificationFormId = 0,
                Name = name,
            };

            IntermediateCertificationFormValidator validator = new IntermediateCertificationFormValidator();

            // act
            var result = validator.Validate(IntermediateCertificationForm);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("rrikt")]
        public async Task Validate_IntermediateCertificationFormIsValid_ShouldHaveNoErrors(string name)
        {
            // arrange
            IntermediateCertificationForm IntermediateCertificationForm = new IntermediateCertificationForm()
            {
                CertificationFormId = 0,
                Name = name,
            };

            IntermediateCertificationFormValidator validator = new IntermediateCertificationFormValidator();

            // act
            var result = validator.Validate(IntermediateCertificationForm);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
    }
}
