
// Verifikationsrad

using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

public class VerificationEntry
{
    // public Guid VoucherId { get; init; }


    // Konto
    public required Account Account { get; init; }

    // Debet
    public decimal Debit { get; init; }

    // Kredit
    public decimal Credit { get; init; }

    // Momssats
    public VATRate? VATRate { get; init; }

    public override string ToString()
    {
        return $"VerificationEntry: Account: {Account}, Debit: {Debit}, Credit: {Credit}, VATRate: {VATRate}";
    }
}