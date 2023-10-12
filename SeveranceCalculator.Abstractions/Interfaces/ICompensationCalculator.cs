using SeveranceCalculator.Abstractions.Models;

namespace SeveranceCalculator.Abstractions.Interfaces;

public interface ICompensationCalculator
{
    decimal CalculateCompensation(
        Employee employee 
    );

    decimal CalculateYearEndBonus(
        Employee employee);

    decimal CalculateSeniorityPremium(Employee employee);
}