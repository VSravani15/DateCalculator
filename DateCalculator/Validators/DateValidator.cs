using DateCalculator.Helpers;
using DateCalculator.Interfaces;
using DateCalculator.Models;

namespace DateCalculator.Validators;

public class DateValidator : IDateValidator
{
    public bool IsValid(SimpleDate date)
    {
        if (date == null)
            return false;

        if (date.Year < 1)
            return false;

        if (date.Month < 1 || date.Month > 12)
            return false;

        int daysInMonth =
            DaysInMonthHelper.GetDaysInMonth(
                date.Month,
                date.Year);

        if (date.Day < 1 || date.Day > daysInMonth)
            return false;

        return true;
    }
}