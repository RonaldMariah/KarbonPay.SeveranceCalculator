using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;

namespace SeveranceCalculator.Mexico.Services;

public class MexicanVacationCalculator: IVacationCalculator
{
    public decimal CalculateVacationPay(Employee employee)
    {
        return employee.NumberOfVacationDaysAvailable * employee.GetDailySalary();
    }

    public decimal GetVacationPremium(Employee employee)
    {
        return CalculateVacationPay(employee) * 0.25m;
    }
    
    public static int GetNumberOfAllowedVacationDays(Employee employee)
    {
        var yearsOfService = employee.GetNumberOfYearsService();
        return yearsOfService switch
        {
            1 => 12,
            2 => 14,
            3 => 16,
            >= 4 and <= 5 => 18,
            >= 6 and <= 10 => 20,
            >= 11 and <= 15 => 22,
            _ => 0
        };
    }
}