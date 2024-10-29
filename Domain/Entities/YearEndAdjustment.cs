using Domain.Enums;

// Bokslutstransaktion
namespace Domain.Entities;

public class YearEndAdjustment
{
    // Beskrivning
    public string Description { get; init; }
    
    // Verifikationsrader
    public List<VoucherEntry> Entries { get; init; }
    
    // Typ av justering
    public AdjustmentType Type { get; init; }
}