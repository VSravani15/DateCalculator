# Date Calculator

## Overview

Date Calculator is a .NET 8 Console Application that calculates a future date by adding a given number of days to an input date.

The application implements custom date calculation logic without using the built-in `DateTime` class.

The solution handles:
- Leap year calculation
- Days in month calculation
- Date validation
- Month and year transitions
- User input validation

---

## Technologies Used

- .NET 8
- C#
- xUnit (Unit Testing)
- Microsoft Dependency Injection

---

## Features

### Date Calculation
- Add days to a given date
- Handle month changes
- Handle year changes
- Handle leap years correctly

### Validation
- Validates date input
- Handles invalid dates:
  - 31/04/2026
  - 29/02/2023
- Handles invalid numeric input
- Prevents negative day additions

### Design
- Interface-based service design
- Dependency Injection
- Separation of concerns
- Unit test coverage

---

## Project Structure

```
DateCalculator
│
├── Helpers
│   ├── LeapYearHelper.cs
│   └── DaysInMonthHelper.cs
│
├── Interfaces
│   ├── IDateCalculatorService.cs
│   └── IDateValidator.cs
│
├── Models
│   └── SimpleDate.cs
│
├── Parsers
│   └── DateParser.cs
│
├── Services
│   └── DateCalculatorService.cs
│
├── Validators
│   └── DateValidator.cs
│
├── Program.cs
│
└── DateCalculator.Tests
    ├── LeapYearTests.cs
    ├── DateValidatorTests.cs
    ├── DateCalculatorServiceTests.cs
    └── DateParserTests.cs
```

---

## Design Approach

The application follows a layered architecture.

### Program Layer
Responsible for:
- Reading user input
- Displaying output
- Handling user-friendly error messages

### Parser Layer
Responsible for:
- Converting string input into `SimpleDate` objects

### Validator Layer
Responsible for:
- Checking whether the provided date is valid

### Service Layer
Responsible for:
- Performing date calculations

### Helper Layer
Responsible for:
- Leap year logic
- Days in month calculation

---

## Dependency Injection

The application uses Microsoft Dependency Injection.

Services are registered using interfaces:

Example:

```csharp
services.AddTransient<IDateValidator, DateValidator>();

services.AddTransient<IDateCalculatorService, DateCalculatorService>();
```

This keeps the application loosely coupled and improves maintainability.

---

## Requirements

- .NET 8 SDK
- Visual Studio 2022 or later

---

## Running the Application

Clone the repository:

```bash
git clone <repository-url>
git clone git@github.com:VSravani15/DateCalculator.git
```

Navigate to the project folder:

```bash
cd DateCalculator/DateCalculator
```

Run:

```bash
dotnet run
```

---

## Sample Execution

### Input

```
Enter date (dd/MM/yyyy):
31/01/2016

Enter number of days to add:
1
```

### Output

```
New Date:
01/02/2016
```

---

## Additional Examples

| Input Date | Days Added | Expected Result |
|------------|------------|----------------|
| 31/01/2016 | 1 | 01/02/2016 |
| 28/02/2024 | 1 | 29/02/2024 |
| 31/12/2026 | 1 | 01/01/2027 |
| 29/02/2023 | 1 | Invalid Date |

---

## Running Unit Tests

Navigate to the project folder:

```bash
cd DateCalculator/DateCalculator.Tests
```

Run all tests:

```bash
dotnet test
```

The test suite covers:

- Leap year scenarios
- Date validation scenarios
- Date calculation scenarios
- Invalid input scenarios

Example:

```
Passed! 
Failed: 0
```

---

## Error Handling

The application handles:

- Invalid date formats
- Non-numeric input
- Invalid calendar dates
- Negative day values

Example:

```
Input:
abc/01/2026

Output:
Invalid date format
```

---

## Author

Sravani
