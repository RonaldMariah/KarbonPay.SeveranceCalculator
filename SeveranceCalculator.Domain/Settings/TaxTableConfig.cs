using SeveranceCalculator.Domain.Entities;

namespace SeveranceCalculator.Domain.Settings;

public class TaxTableConfig
{
    public required List<TaxBracket> Brackets { get; set; }
}