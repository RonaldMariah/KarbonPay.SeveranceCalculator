using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Services;

namespace SeveranceCalculator.Tests.Domain;

[TestFixture]
public class CompensationCalculatorTests
{
    private MexicanCompensationCalculator _mexicanCompensationCalculator = null!;
    
    [SetUp]
    public void SetUp()
    {
        _mexicanCompensationCalculator = new MexicanCompensationCalculator(20, 15, 103.74m);
    }

    [Test]
    public void CalculateCompensation_EmployeeWorkedThreeYears_ShouldGetCorrectValue()
    {
        // Arrange
        var employee = new Employee(25500m, DateTime.Today - TimeSpan.FromDays(366*3), 0,
            TerminationReason.TerminationWithoutJustCause);
        
        // Act
        var actualCompensation = _mexicanCompensationCalculator.CalculateCompensation(employee);
        var expected = 53442.90m;
        
        // Assert
        Assert.That(actualCompensation, Is.EqualTo(expected), "The actual compensation does not match the expected compensation.");
    }
    
    [Test]
    public void CalculateCompensationAguinaldo_EmployeeWorkedThreeYears_ShouldGetCorrectValue()
    {
        // Arrange
        var employee = new Employee(25500m, DateTime.Today - TimeSpan.FromDays(366*3), 0,
            TerminationReason.TerminationWithoutJustCause);
        
        // Act
        var actualCompensation = _mexicanCompensationCalculator.CalculateYearEndBonus(employee);
        var expected = 12750.0m;
        
        // Assert
        Assert.That(actualCompensation, Is.EqualTo(expected), "The actual year end bonus does not match the expected year end bonus.");
    }
    
    [Test]
    public void CalculateCompensationSeniority_EmployeeWorkedThreeYears_ShouldGetCorrectValue()
    {
        // Arrange
        var employee = new Employee(25500m, DateTime.Today - TimeSpan.FromDays(366*3), 10,
            TerminationReason.TerminationWithoutJustCause);
        
        // Act
        var actualCompensation = _mexicanCompensationCalculator.CalculateSeniorityPremium(employee);
        var expected = 7469.28m;
        
        // Assert
        Assert.That(actualCompensation, Is.EqualTo(expected), "The actual seniority premium does not match the expected seniority premium.");
    }
}