using SeveranceCalculator.Abstractions.Models;

namespace SeveranceCalculator.Abstractions.Interfaces;

public interface ITaxCalculator
{
    decimal CalculateTax(
        Employee employee
    );
}