// Verifikation

using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

// Verifikation
public class Verification
{
    // Verifikationsnummer (normalt år + löpnummer)

    public int Id { get; set; }
    public string Number => $"{Date.Year}-{Id}";               // Verifikationsnummer

    // Bokföringsdatum
    public DateTime Date { get; init; }

    // Beskrivning/text
    public required string Description { get; init; }

    // Verifikationsrader
    public required List<VerificationEntry> Entries { get; init; }

    public bool IsJournalVoucher { get; init; } // True if manually created (bokföringsorder)

    // Bilagor/underlag
    public required List<Attachment> Attachments { get; init; }

    // Verifikationstyp
    public VoucherType Type { get; init; }
    public override string ToString()
    {
        return $"Verification: {Id}, Date: {Date}, Description: {Description}, Type: {Type}";
    }
}