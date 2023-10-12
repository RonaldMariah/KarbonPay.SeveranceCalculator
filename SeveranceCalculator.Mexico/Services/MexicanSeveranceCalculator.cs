using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Mexico.Models;

namespace SeveranceCalculator.Mexico.Services;

public class MexicanSeveranceCalculator(
        ICompensationCalculator compensationCalculator,
        IIndemnityCalculator indemnityCalculator,
        ITaxCalculator taxCalculator,
        IVacationCalculator vacationCalculator)
    : ISeveranceCalculator
{
    public IBaseSeverancePackage CalculateSeverance(
        Employee employee,
        int indemnityDays)
    {
        var compensation = compensationCalculator.CalculateCompensation(employee);
        var indemnity = indemnityCalculator.CalculateIndemnity();
        var vacationPay = vacationCalculator.CalculateVacationPay(employee);
        var vacationPremium = vacationCalculator.GetVacationPremium(employee);
        var withholdingTax = taxCalculator.CalculateTax(employee);
        var aguinaldo = compensationCalculator.CalculateYearEndBonus(employee);
        var seniorityPremium = compensationCalculator.CalculateSeniorityPremium(employee);

        var totalAmount = compensation + indemnity + vacationPay + vacationPremium + aguinaldo + seniorityPremium;
        return new MexicanSeverancePackage
        {
            Compensation = compensation,
            Indemnity = indemnity,
            VacationPay = vacationPay,
            VacationPremium = vacationPremium,
            WithholdingTax = withholdingTax,
            YearEndBonus = aguinaldo,
            SeniorityPremium = seniorityPremium,
            TotalAmount = totalAmount
        };
    }
}