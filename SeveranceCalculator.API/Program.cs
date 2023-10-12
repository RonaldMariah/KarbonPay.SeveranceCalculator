using System.Text.Json;
using SeveranceCalculator.Abstractions.Models;
using SeveranceCalculator.Domain.Entities;
using SeveranceCalculator.Domain.Enums;
using SeveranceCalculator.Mexico.Factories;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Get the configuration
var configuration = builder.Configuration;

// Read the TaxTable section and store it in a variable
var taxTable = new TaxTable(configuration.GetSection("TaxTable").Get<List<TaxBracket>>() ?? new List<TaxBracket>());
var compensationDaysPerYear = configuration.GetValue<int>("Compensation:DaysPerYear");
var indemnityDays = configuration.GetValue<int>("Indemnity:Days");
var umaValue = configuration.GetValue<decimal>("UMA:DailyValue");
var aguinaldoDays = configuration.GetValue<int>("AguinaldoDays");

app.MapGet("/calculate", (decimal salary, DateTime employmentStartDate, int numberOfVacationDays) =>
{
    var employee = new Employee(
        salary,
        employmentStartDate,
        numberOfVacationDays,
        TerminationReason.TerminationWithoutJustCause);
        
    var severanceCalculator = 
        new MexicanSeveranceCalculatorFactory().CreateSeveranceCalculator(
            employee,
            taxTable,
            compensationDaysPerYear, 
            indemnityDays,
            aguinaldoDays,
            umaValue);
    
    var severance = severanceCalculator.CalculateSeverance(
        employee,
        indemnityDays);
    
    return severance;
});

app.Run();