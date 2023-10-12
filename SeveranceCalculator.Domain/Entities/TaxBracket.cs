namespace SeveranceCalculator.Domain.Entities;

public class TaxBracket
{
    public decimal MinimumIncome { get; set; }
    public decimal MaximumIncome { get; set; }
    public decimal TaxPercentage { get; set; }
    public decimal ExcessOnTax { get; set; }
}