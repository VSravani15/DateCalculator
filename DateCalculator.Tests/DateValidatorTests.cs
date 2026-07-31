using DateCalculator.Models;
using DateCalculator.Validators;

namespace DateCalculator.Tests;

public class DateValidatorTests
{
    private readonly DateValidator _validator = new();

    [Fact]
    public void Valid_Date_Should_Return_True()
    {
        // Arrange
        var date = new SimpleDate
        {
            Day = 31,
            Month = 1,
            Year = 2026
        };

        // Act
        bool result = _validator.IsValid(date);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Invalid_Date_Should_Return_False()
    {
        // Arrange
        var date = new SimpleDate
        {
            Day = 31,
            Month = 4,
            Year = 2026
        };

        // Act
        bool result = _validator.IsValid(date);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Leap_Year_Date_Should_Return_True()
    {
        var date = new SimpleDate
        {
            Day = 29,
            Month = 2,
            Year = 2024
        };

        Assert.True(_validator.IsValid(date));
    }

    [Fact]
    public void Non_Leap_Year_Date_Should_Return_False()
    {
        var date = new SimpleDate
        {
            Day = 29,
            Month = 2,
            Year = 2023
        };

        Assert.False(_validator.IsValid(date));
    }
}