// Verifikation



using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

// Verifikation
public class Voucher
{
    // Verifikationsnummer (normalt år + löpnummer)
    public required string Id { get; init; }

    // Bokföringsdatum
    public DateTime Date { get; init; }

    // Beskrivning/text
    public required string Description { get; init; }

    // Verifikationsrader
    public required List<VoucherEntry> Entries { get; init; }

    // Bilagor/underlag
    public required List<Attachment> Attachments { get; init; }

    // Verifikationstyp
    public VoucherType Type { get; init; }
}