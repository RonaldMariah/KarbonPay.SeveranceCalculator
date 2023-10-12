using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Entities;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Factories;

namespace SeveranceCalculator.Tests.Domain;

[TestFixture]
public class SeveranceCalculatorTests
{
    private ISeveranceCalculator _severanceCalculator = null!;
    private TaxTable _taxTable = null!;
    private Employee _employee = null!;

    [SetUp]
    public void SetUp()
    {
        _employee = new Employee(25500m, DateTime.Today - TimeSpan.FromDays(366*3), 10,
            TerminationReason.TerminationWithoutJustCause);
        
        var brackets = new List<TaxBracket>{
            new TaxBracket { MinimumIncome = 0.01m, MaximumIncome = 746.04m, TaxPercentage = 1.92m, ExcessOnTax = 0 },
            new TaxBracket { MinimumIncome = 746.05m, MaximumIncome = 6332.05m, TaxPercentage = 6.4m, ExcessOnTax = 14.32m },
            new TaxBracket { MinimumIncome = 6332.06m, MaximumIncome = 11128.01m, TaxPercentage = 10.88m, ExcessOnTax = 371.83m },
            new TaxBracket { MinimumIncome = 11128.02m, MaximumIncome = 12935.82m, TaxPercentage = 16m, ExcessOnTax = 893.63m },
            new TaxBracket { MinimumIncome = 12935.83m, MaximumIncome = 15487.71m, TaxPercentage = 17.92m, ExcessOnTax = 1182.88m },
            new TaxBracket { MinimumIncome = 15487.72m, MaximumIncome = 31236.49m, TaxPercentage = 21.36m, ExcessOnTax = 1640.18m },
            new TaxBracket { MinimumIncome = 31236.50m, MaximumIncome = 49233.00m, TaxPercentage = 23.52m, ExcessOnTax = 5004.12m },
            new TaxBracket { MinimumIncome = 49233.01m, MaximumIncome = 93993.90m, TaxPercentage = 30m, ExcessOnTax = 9236.89m },
            new TaxBracket { MinimumIncome = 93993.91m, MaximumIncome = 125325.20m, TaxPercentage = 32m, ExcessOnTax = 22665.17m },
            new TaxBracket { MinimumIncome = 125325.21m, MaximumIncome = 375975.61m, TaxPercentage = 34m, ExcessOnTax = 32691.18m },
            new TaxBracket { MinimumIncome = 375975.62m, MaximumIncome = decimal.MaxValue, TaxPercentage = 35m, ExcessOnTax = 117912.32m }
        };

        _taxTable = new TaxTable(brackets);
        _severanceCalculator = new MexicanSeveranceCalculatorFactory().CreateSeveranceCalculator(_employee, _taxTable, 20, 90, 15, 103.74m);

    }

    [Test]
    public void CalculateSeverancePay_ForAssessmentExample_ShouldReturnCorrectValue()
    {
        // Act
        var actualCompensation = _severanceCalculator.CalculateSeverance(_employee, 90);
        var expected = 164451.53m;
        
        // Assert
        Assert.That(actualCompensation.TotalAmount, Is.EqualTo(expected), "The actual compensation does not match the expected compensation.");
    }
}