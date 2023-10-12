using SeveranceCalculator.Abstractions.Interfaces;
using SeveranceCalculator.Mexico.Models;

namespace SeveranceCalculator.Web.Services;

public class CalculatorService(IConfiguration configuration): ICalculatorService
{
    private readonly string? _calculatorApiBaseUrl = configuration["CalculatorApiHost"];

    public async Task<IBaseSeverancePackage?> CalculateSeverance(
        decimal salary,
        DateTime employmentStartDate,
        int numberOfVacationDays)
    {
        using var client = new HttpClient();
        var apiUrl = $"{_calculatorApiBaseUrl}/calculate?salary={salary}&employmentStartDate={employmentStartDate}&numberOfVacationDays={numberOfVacationDays}";
        
        var response = await client.GetAsync(apiUrl);
        if (!response.IsSuccessStatusCode) 
            return null;
        
        var responseContent = await response.Content.ReadFromJsonAsync<MexicanSeverancePackage>();
        return responseContent;
    }
}