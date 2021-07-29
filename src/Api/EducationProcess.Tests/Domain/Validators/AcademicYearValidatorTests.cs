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
        public async Task Validate_AcademicYearIsNotValid_ShouldHaveErrors(ushort beginingYear, ushort endingYear)
        {
            // arrange - подготавливаем данные
            AcademicYear academicYear = new AcademicYear()
            {
                AcademicYearId = 0,
                BeginingYear = beginingYear,
                EndingYear = endingYear
            };

            AcademicYearValidator validator = new AcademicYearValidator();

            // act - запускаем тестируемый метод
            var result = validator.Validate(academicYear);

            // assert - проверяем/валидируем результаты теста
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData(2021, 2021)]
        [InlineData(2021, 2022)]
        [InlineData(2030, 2031)]
        public async Task Validate_AcademicYearIsValid_ShouldNotHaveErrors(ushort beginingYear, ushort endingYear)
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