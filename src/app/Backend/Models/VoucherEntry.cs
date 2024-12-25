
// Verifikationsrad

using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

public class VoucherEntry
{
    // Konto
    public required Account Account { get; init; }

    // Debet
    public decimal Debit { get; init; }

    // Kredit
    public decimal Credit { get; init; }

    // Momssats
    public VATRate? VATRate { get; init; }
}