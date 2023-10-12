using SeveranceCalculator.Abstractions.AbstractFactories;
using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Entities;
using SeveranceCalculator.Mexico.Services;

namespace SeveranceCalculator.Mexico.Factories;

public class MexicanSeveranceCalculatorFactory: ISeveranceCalculatorFactory
{
    public ISeveranceCalculator CreateSeveranceCalculator(
        Employee employee,
        TaxTable taxTable, 
        int compensationDaysPerYear,
        int indemnityDays,
        int aguinaldoDays, 
        decimal umaValue)
    {
        return new MexicanSeveranceCalculator(
            CreateCompensationCalculator(compensationDaysPerYear, aguinaldoDays, umaValue),
            CreateIndemnityCalculator(employee, indemnityDays),
            CreateTaxCalculator(taxTable),
            CreateVacationCalculator());
    }

    public ITaxCalculator CreateTaxCalculator(TaxTable taxTable)
    {
        return new MexicanTaxCalculator(taxTable);
    }

    public IVacationCalculator CreateVacationCalculator()
    {
        return new MexicanVacationCalculator();
    }

    public ICompensationCalculator CreateCompensationCalculator(int compensationDaysPerYear, int aguinaldoDays, decimal umaValue)
    {
        return new MexicanCompensationCalculator(compensationDaysPerYear, aguinaldoDays, umaValue);
    }

    public IIndemnityCalculator CreateIndemnityCalculator(Employee employee, int indemnityDays)
    {
        return new MexicanIndemnityCalculator(employee, indemnityDays);
    }
}