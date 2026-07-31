using DateCalculator.Interfaces;
using DateCalculator.Models;
using DateCalculator.Services;
using DateCalculator.Validators;
using DateCalculator.Parsers;
using Microsoft.Extensions.DependencyInjection;


// Create service collection
var services = new ServiceCollection();


// Register dependencies
services.AddTransient<IDateValidator, DateValidator>();

services.AddTransient<IDateCalculatorService, DateCalculatorService>();


// Build service provider
var serviceProvider = services.BuildServiceProvider();


// Get service from DI container
var calculator =
    serviceProvider.GetRequiredService<IDateCalculatorService>();

try
{
    Console.Write("Enter date (dd/MM/yyyy): ");
    var inputDate = Console.ReadLine();


    Console.Write("Enter number of days to add: ");
    var inputDays = Console.ReadLine();


    if (!DateParser.TryParse(inputDate, out SimpleDate date))
    {
        Console.WriteLine("Invalid date format");
        return;
    }



    // Parse days
    if (!int.TryParse(inputDays, out int days))
    {
        Console.WriteLine("Days must be a valid number");
        return;
    }
    if (days < 0)
    {
        Console.WriteLine("Days must be a positive number");
        return;
    }


    var result = calculator.AddDays(date, days);


    Console.WriteLine();
    Console.WriteLine($"New Date: {result}");

}
catch (ArgumentException ex)
{
    Console.WriteLine();
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception)
{
    Console.WriteLine();
    Console.WriteLine("Unexpected error occurred");
}

