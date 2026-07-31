using DateCalculator.Models;

namespace DateCalculator.Parsers;

public static class DateParser
{
    public static bool TryParse(string input, out SimpleDate date)
    {
        date = null!;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }


        var parts = input.Split('/');


        if (parts.Length != 3)
        {
            return false;
        }


        if (!int.TryParse(parts[0], out int day) ||
           !int.TryParse(parts[1], out int month) ||
           !int.TryParse(parts[2], out int year))
        {
            return false;
        }


        date = new SimpleDate
        {
            Day = day,
            Month = month,
            Year = year
        };


        return true;
    }
}