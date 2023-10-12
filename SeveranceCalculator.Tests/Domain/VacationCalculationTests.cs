using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Services;

namespace SeveranceCalculator.Tests.Domain;

[TestFixture]
public class VacationCalculationTests
{
    private MexicanVacationCalculator _mexicanVacationCalculator;
    
    [SetUp]
    public void SetUp()
    {
        _mexicanVacationCalculator = new MexicanVacationCalculator();
    }

    [Test]
    [TestCase(366, ExpectedResult = 12)]
    [TestCase(732, ExpectedResult = 14)]
    [TestCase(1099, ExpectedResult = 16)]
    public int CalculateVacationDue_EmployeeWorksXYear_ShouldReturnCorrectDays(int daysAgo)
    {
        // Act
        return MexicanVacationCalculator.GetNumberOfAllowedVacationDays(
            new Employee(0.00m, DateTime.Today - TimeSpan.FromDays(daysAgo), 0, TerminationReason.Other));
    }
}