using EducationProcess.Domain.Models;
using EducationProcess.Domain.Validators;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class ConductedPairValidatorTests
    {

        [Theory]
        [InlineData(null, null)]
        [InlineData(1, 2)]

        public void Validate_ConductedPairIsNotValid_ShouldHaveErrors(int? scheduleDisciplineId, int? scheduleDisciplineReplacementId)
        {
            // arrange
            ConductedPair ConductedPair = new ConductedPair()
            {
                ConductedPairId = 0,
                ScheduleDisciplineId = scheduleDisciplineId,
                ScheduleDisciplineReplacementId = scheduleDisciplineReplacementId
            };

            ConductedPairValidator validator = new ConductedPairValidator();

            // act
            var result = validator.Validate(ConductedPair);

            // assert
            Assert.False(result.Errors.Count == 0);
        }
        [Theory]
        [InlineData(1, null)]
        [InlineData(null, 1)]
        public void Validate_ConductedPairIsValid_ShouldHaveNoErrors(int? scheduleDisciplineId, int? scheduleDisciplineReplacementId)
        {
            // arrange
            ConductedPair ConductedPair = new ConductedPair()
            {
                ConductedPairId = 0,
                ScheduleDisciplineId = scheduleDisciplineId,
                ScheduleDisciplineReplacementId = scheduleDisciplineReplacementId
            };

            ConductedPairValidator validator = new ConductedPairValidator();

            // act
            var result = validator.Validate(ConductedPair);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
