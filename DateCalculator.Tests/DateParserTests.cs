using DateCalculator.Parsers;

namespace DateCalculator.Tests;

public class DateParserTests
{
    [Fact]
    public void Valid_Date_String_Should_Parse()
    {
        var result = DateParser.TryParse(
            "31/01/2026",
            out var date);


        Assert.True(result);

        Assert.Equal(31, date.Day);
        Assert.Equal(1, date.Month);
        Assert.Equal(2026, date.Year);
    }


    [Fact]
    public void Invalid_Date_Format_Should_Fail()
    {
        var result = DateParser.TryParse(
            "31-01-2026",
            out var date);


        Assert.False(result);
    }


    [Fact]
    public void Non_Numeric_Date_Should_Fail()
    {
        var result = DateParser.TryParse(
            "abc/01/2026",
            out var date);


        Assert.False(result);
    }
}