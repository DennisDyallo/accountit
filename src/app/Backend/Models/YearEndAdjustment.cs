
using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

// Bokslutstransaktion
public class YearEndAdjustment
{
    // Beskrivning
    public required string Description { get; init; }

    // Verifikationsrader
    public required List<VoucherEntry> Entries { get; init; }

    // Typ av justering
    public AdjustmentType Type { get; init; }
}