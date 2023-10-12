namespace SeveranceCalculator.Domain.Entities;

public class TaxTable(List<TaxBracket> brackets)
{
    private List<TaxBracket> Brackets { get; init; } = brackets;

    public decimal CalculateTax(decimal income)
    {
        var tax = 
            (from bracket in Brackets 
             where income > bracket.MinimumIncome && income <= bracket.MaximumIncome 
             select bracket.ExcessOnTax + (income - bracket.MinimumIncome) / 100 * bracket.TaxPercentage)
            .FirstOrDefault();

        return decimal.Round(tax, decimals: 2);
    }
}