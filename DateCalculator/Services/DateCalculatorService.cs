using DateCalculator.Helpers;
using DateCalculator.Interfaces;
using DateCalculator.Models;
using DateCalculator.Validators;

namespace DateCalculator.Services;


public class DateCalculatorService : IDateCalculatorService
{
    private readonly IDateValidator _validator;
    public DateCalculatorService(
        IDateValidator validator)
    {
        _validator = validator;
    }
    public SimpleDate AddDays(SimpleDate date, int days)
    {
        if (!_validator.IsValid(date))
        {
            throw new ArgumentException($"Invalid date: {date}");
        }
        if (days < 0)
        {
            throw new ArgumentException("Days cannot be negative");
        }
        while (days > 0)
        {
            date.Day++;

            int daysInMonth =
                DaysInMonthHelper.GetDaysInMonth(
                    date.Month,
                    date.Year);


            if (date.Day > daysInMonth)
            {
                date.Day = 1;
                date.Month++;


                if (date.Month > 12)
                {
                    date.Month = 1;
                    date.Year++;
                }
            }

            days--;
        }

        return date;
    }
}