namespace DateCalculator.Interfaces;
using DateCalculator.Models;
public interface IDateValidator
{
    bool IsValid(SimpleDate date);
}