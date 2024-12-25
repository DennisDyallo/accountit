
// Räkenskapsår
namespace Taxana.Backend.Models;

public class FiscalYear
{
    // Period
    public required AccountingPeriod Period { get; init; }

    // Ingående balans
    public decimal OpeningBalance { get; init; }

    // Utgående balans
    public decimal ClosingBalance { get; init; }

    // Låst (efter årsbokslut)
    public bool IsLocked { get; init; }

    // Bokslutstransaktioner
    public required List<YearEndAdjustment> Adjustments { get; init; }
}