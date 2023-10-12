using SeveranceCalculator.Abstractions.Interfaces;

namespace SeveranceCalculator.Web;

public interface ICalculatorService
{
    public Task<IBaseSeverancePackage?> CalculateSeverance(
        decimal salary,
        DateTime employmentStartDate,
        int numberOfVacationDays);
}