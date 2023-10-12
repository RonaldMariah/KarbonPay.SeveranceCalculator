using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Services;

namespace SeveranceCalculator.Tests.Domain;

[TestFixture]
public class EmployeeTests
{

    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public void CalculateVacationPay_ShouldReturnCorrectValue()
    {
        // Arrange
        var employee = new Employee(25500m, DateTime.Now, 10, TerminationReason.Other);
        
        // Act
        var actualVacationPay = new MexicanVacationCalculator().CalculateVacationPay(employee);
        var expected = 8500m;
        
        // Assert
        Assert.That(actualVacationPay, Is.EqualTo(expected), "Vacation pay does not match the expected value.");
    }
    
    [Test]
    public void CalculateVacationPremium_ShouldReturnCorrectValue()
    {
        // Arrange
        var employee = new Employee(25500m, DateTime.Now, 10, TerminationReason.Other);
        
        // Act
        var actualVacationPay = new MexicanVacationCalculator().GetVacationPremium(employee);
        var expected = 2125m;
        
        // Assert
        Assert.That(actualVacationPay, Is.EqualTo(expected), "Vacation premium does not match the expected value.");
    }

}