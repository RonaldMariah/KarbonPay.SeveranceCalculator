using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Services;

namespace SeveranceCalculator.Tests.Domain;

[TestFixture]
public class IndemnityCalculatorTests
{
    private MexicanIndemnityCalculator _mexicanIndemnityCalculator = null!;
    
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void CalculateIndemnity_WithJustCause_ShouldReturn0()
    {
        // Arrange 
        var employee = new Employee(25500m, DateTime.Now, 0, TerminationReason.TerminationWithJustCause);
        _mexicanIndemnityCalculator = new MexicanIndemnityCalculator(employee, 90);
        
        // Act
        var actualIndemnity = _mexicanIndemnityCalculator.CalculateIndemnity();
        var expected = 0.0m;
        
        Assert.That(actualIndemnity, Is.EqualTo(expected), "Calculated Indemnity does not match the expected value.");
    }
    
    [Test]
    public void CalculateIndemnity_WithoutJustCause_ShouldReturnCorrectValue()
    {
        // Arrange
        var employee = new Employee(25500.0m, DateTime.Now, 0, TerminationReason.TerminationWithoutJustCause);
        _mexicanIndemnityCalculator = new MexicanIndemnityCalculator(employee, 90);
        
        // Act
        var actualIndemnity = _mexicanIndemnityCalculator.CalculateIndemnity();
        var expected = 80164.35m;
        
        Assert.That(actualIndemnity, Is.EqualTo(expected), "Calculated Indemnity does not match the expected value.");
    }
}