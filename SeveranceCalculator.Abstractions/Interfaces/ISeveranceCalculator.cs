using SeveranceCalculator.Abstractions.Models;

namespace SeveranceCalculator.Abstractions.Interfaces;

public interface ISeveranceCalculator
{
    IBaseSeverancePackage CalculateSeverance(
        Employee employee,
        int indemnityDays);
}