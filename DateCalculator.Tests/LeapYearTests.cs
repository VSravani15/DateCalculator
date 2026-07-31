using DateCalculator.Helpers;
using Xunit;

namespace DateCalculator.Tests;

public class LeapYearTests
{
    [Fact]
    public void Year_2024_Should_Be_LeapYear()
    {
        bool result = LeapYearHelper.IsLeapYear(2024);

        Assert.True(result);
    }

    [Fact]
    public void Year_2023_Should_Not_Be_LeapYear()
    {
        bool result = LeapYearHelper.IsLeapYear(2023);

        Assert.False(result);
    }
}