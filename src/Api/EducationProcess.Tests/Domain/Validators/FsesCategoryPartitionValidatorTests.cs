﻿using EducationProcess.Domain.Validators;
using EducationProcess.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace EducationProcess.Tests.Domain.Validators
{
    public class FsesCategoryPartitionValidatorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("         ", "      ")]
        [InlineData("dsgswe", "")]
        [InlineData("", "khv")]

        public void Validate_FsesCategoryPartitionIsNotValid_ShouldHaveErrors(string name, string nameAbbreviation)
        {
            // arrange
            FsesCategoryPartition FsesCategoryPartition = new FsesCategoryPartition()
            {
                FsesCategoryPartitionId = 0,
                Name = name,
                NameAbbreviation = nameAbbreviation
            };

            FsesCategoryPartitionValidator validator = new FsesCategoryPartitionValidator();

            // act
            var result = validator.Validate(FsesCategoryPartition);

            // assert
            Assert.False(result.Errors.Count == 0);
        }

        [Theory]
        [InlineData("ddsg", "vlogkmelel")]

        public void Validate_FsesCategoryPartitionIsValid_ShouldHaveNoErrors(string name, string nameAbbreviation)
        {
            // arrange
            FsesCategoryPartition FsesCategoryPartition = new FsesCategoryPartition()
            {
                FsesCategoryPartitionId = 0,
                Name = name,
                NameAbbreviation = nameAbbreviation
            };

            FsesCategoryPartitionValidator validator = new FsesCategoryPartitionValidator();

            // act
            var result = validator.Validate(FsesCategoryPartition);

            // assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}
