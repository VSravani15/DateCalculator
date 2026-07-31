using DateCalculator.Models;
using DateCalculator.Services;
using DateCalculator.Validators;

namespace DateCalculator.Tests;

public class DateCalculatorServiceTests
{
    private readonly DateCalculatorService _service =
        new(new DateValidator());

    [Fact]
    public void Add_One_Day_Should_Move_To_Next_Month()
    {
        // Arrange
        var date = new SimpleDate
        {
            Day = 31,
            Month = 1,
            Year = 2016
        };

        // Act
        var result = _service.AddDays(date, 1);

        // Assert
        Assert.Equal(1, result.Day);
        Assert.Equal(2, result.Month);
        Assert.Equal(2016, result.Year);
    }

    [Fact]
    public void Add_One_Day_In_Leap_Year_Should_Return_29_Feb()
    {
        var date = new SimpleDate
        {
            Day = 28,
            Month = 2,
            Year = 2024
        };

        var result = _service.AddDays(date, 1);

        Assert.Equal(29, result.Day);
        Assert.Equal(2, result.Month);
        Assert.Equal(2024, result.Year);
    }

    [Fact]
    public void Add_One_Day_Should_Move_To_Next_Year()
    {
        var date = new SimpleDate
        {
            Day = 31,
            Month = 12,
            Year = 2026
        };

        var result = _service.AddDays(date, 1);

        Assert.Equal(1, result.Day);
        Assert.Equal(1, result.Month);
        Assert.Equal(2027, result.Year);
    }

    [Fact]
    public void Invalid_Date_Should_Throw_Exception()
    {
        var date = new SimpleDate
        {
            Day = 29,
            Month = 2,
            Year = 2023
        };

        Assert.Throws<ArgumentException>(() =>
            _service.AddDays(date, 1));
    }

    [Fact]
    public void Negative_Days_Should_Throw_Exception()
    {
        var date = new SimpleDate
        {
            Day = 1,
            Month = 1,
            Year = 2026
        };

        Assert.Throws<ArgumentException>(() =>
            _service.AddDays(date, -1));
    }
}