using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeveranceCalculator.Abstractions.Interfaces;

namespace SeveranceCalculator.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICalculatorService _calculatorService;

    [BindProperty]
    [Required(ErrorMessage = "Salary is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    
    public decimal Salary { get; set; }
    
    [BindProperty]
    [Required(ErrorMessage = "Number of vacation days is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Number of vacation days must be a non-negative integer.")]
    public int NumberOfVacationDays { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Employment start date is required.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Employment Start Date")]
    public DateTime EmploymentStartDate { get; set; }
    
    public IBaseSeverancePackage? SeverancePackage { get; set; }

    public IndexModel(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
        
        Salary = 25500;
        EmploymentStartDate = DateTime.Now - TimeSpan.FromDays(365.25 * 3);
        NumberOfVacationDays = 10;
    }
    
    public void OnGet()
    {
    }
    
    public async Task OnPost()
    {
        SeverancePackage = await _calculatorService.CalculateSeverance(Salary, EmploymentStartDate, NumberOfVacationDays);
    }
}