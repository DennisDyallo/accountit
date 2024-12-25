
// Räkenskapsår
namespace Domain.Entities;

public class FiscalYear
{
    // Period
    public AccountingPeriod Period { get; init; }
    
    // Ingående balans
    public decimal OpeningBalance { get; init; }
    
    // Utgående balans
    public decimal ClosingBalance { get; init; }
    
    // Låst (efter årsbokslut)
    public bool IsLocked { get; init; }
    
    // Bokslutstransaktioner
    public List<YearEndAdjustment> Adjustments { get; init; }
}