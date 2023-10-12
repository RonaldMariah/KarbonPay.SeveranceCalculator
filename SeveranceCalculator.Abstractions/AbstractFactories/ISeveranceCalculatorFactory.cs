using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Entities;

namespace SeveranceCalculator.Abstractions.AbstractFactories;

public interface ISeveranceCalculatorFactory
{
    ISeveranceCalculator CreateSeveranceCalculator(
        Employee employee,
        TaxTable taxTable, 
        int compensationDaysPerYear,
        int indemnityDays,
        int aguinaldoDays, 
        decimal umaValue);
    
    ITaxCalculator CreateTaxCalculator(TaxTable taxTable);
    IVacationCalculator CreateVacationCalculator();
    ICompensationCalculator CreateCompensationCalculator(int compensationDaysPerYear, int aguinaldoDays, decimal umaValue);
    IIndemnityCalculator CreateIndemnityCalculator(Employee employee, int indemnityDays);
}