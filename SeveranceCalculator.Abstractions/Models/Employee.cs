using SeveranceCalculator.Domain.Enums;

namespace SeveranceCalculator.Abstractions.Models;

public class Employee(
    decimal monthlySalary, 
    DateTime employmentStartDate, 
    int numberOfVacationDaysAvailable, 
    TerminationReason terminationReason)
{
    public decimal MonthlySalary { get; set; } = monthlySalary;
    private DateTime EmploymentStartDate { get; set; } = employmentStartDate;
    public int NumberOfVacationDaysAvailable { get; set; } = numberOfVacationDaysAvailable;

    public TerminationReason TerminationReason { get; set; } = terminationReason;

    public decimal GetDailySalary()
    {
        return decimal.Round(MonthlySalary / 30.0m, decimals: 2);
    }

    public int GetNumberOfYearsService()
    {
        var timeSpan = DateTime.Now - EmploymentStartDate;
        return (int)(timeSpan.TotalDays / 365.25);
    }
}