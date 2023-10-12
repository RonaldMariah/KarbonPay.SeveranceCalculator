using SeveranceCalculator.Abstractions.Models;

namespace SeveranceCalculator.Abstractions.Interfaces;

public interface IVacationCalculator
{
    decimal CalculateVacationPay(
        Employee employee
    );

    decimal GetVacationPremium(Employee employee);
}