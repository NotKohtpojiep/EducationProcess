using System.Threading.Tasks;
using EducationProcess.Domain.Models;
using EducationProcess.Domain.Validators;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class AcademicYearValidatorTests
    {
        public AcademicYearValidatorTests()
        {

        }

        [Theory]
        [InlineData(2021, 2020)]
        [InlineData(1000, 2020)]
        [InlineData(2090, 2020)]
        [InlineData(1233, 2020)]
        public void Validate_AcademicYearIsNotValid_ShouldHaveErrors(short beginingYear, short endingYear)
        {
            // arrange
            AcademicYear academicYear = new AcademicYear()
            {
                AcademicYearId = 0,
                BeginingYear = beginingYear,
                EndingYear = endingYear
            };

            AcademicYearValidator validator = new AcademicYearValidator();

            // act
            var result = validator.Validate(academicYear);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData(2021, 2021)]
        [InlineData(2021, 2022)]
        [InlineData(2030, 2031)]
        public void Validate_AcademicYearIsValid_ShouldNotHaveErrors(short beginingYear, short endingYear)
        {
            // arrange
            AcademicYear academicYear = new AcademicYear()
            {
                AcademicYearId = 0,
                BeginingYear = beginingYear,
                EndingYear = endingYear
            };

            AcademicYearValidator validator = new AcademicYearValidator();

            // act
            var result = validator.Validate(academicYear);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}