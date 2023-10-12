using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Settings;

namespace SeveranceCalculator.Mexico.Services;

public class MexicanIndemnityCalculator(Employee employee, int indemnityDays) : IIndemnityCalculator
{
    public decimal CalculateIndemnity()
    {
        return employee.TerminationReason == TerminationReason.TerminationWithoutJustCause ? 
            decimal.Round(indemnityDays * employee.GetDailySalary() * Constants.SDI_CONSTANT, 2) : 
            0.0m;
    }
}