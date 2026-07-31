using DateCalculator.Models;

namespace DateCalculator.Interfaces;

public interface IDateCalculatorService
{
    SimpleDate AddDays(SimpleDate date, int days);
}