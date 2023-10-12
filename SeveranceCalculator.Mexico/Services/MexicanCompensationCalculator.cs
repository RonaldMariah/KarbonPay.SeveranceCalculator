using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Settings;

namespace SeveranceCalculator.Mexico.Services;

public class MexicanCompensationCalculator
    (int daysPerYear, int aguinaldoDays, decimal umaValue) : ICompensationCalculator
{
    public decimal CalculateCompensation(Employee employee)
    {
        return employee.TerminationReason == TerminationReason.TerminationWithoutJustCause ? 
            decimal.Round(daysPerYear * employee.GetDailySalary() * Constants.SDI_CONSTANT * employee.GetNumberOfYearsService(), 2) : 
            0.0m;
    }

    public decimal CalculateYearEndBonus(Employee employee)
    {
        return decimal.Round(employee.GetDailySalary() * aguinaldoDays, 2);
    }

    public decimal CalculateSeniorityPremium(Employee employee)
    {
        var multiplier = Math.Min(2 * umaValue, employee.GetDailySalary());
        return decimal.Round(multiplier * 12 * employee.GetNumberOfYearsService(), 2);
    }
}