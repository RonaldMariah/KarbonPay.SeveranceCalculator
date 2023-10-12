namespace SeveranceCalculator.Abstractions.Interfaces;

public interface IBaseSeverancePackage
{
    public decimal TotalAmount { get; set; }
    public decimal SeniorityPremium { get; set; }
    public decimal YearEndBonus { get; set; }
    public decimal WithholdingTax { get; set; }
    public decimal VacationPremium { get; set; }
    public decimal VacationPay { get; set; }
    public decimal Indemnity { get; set; }
    public decimal Compensation { get; set; }
}