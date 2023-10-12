using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Entities;

namespace SeveranceCalculator.Mexico.Services;

public class MexicanTaxCalculator(TaxTable taxTable) : ITaxCalculator
{
    public decimal CalculateTax(
        Employee employee)
    {
        return taxTable.CalculateTax(employee.MonthlySalary);
    }
}