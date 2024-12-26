// Verifikation



using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

// Verifikation
public class Voucher
{
    // Verifikationsnummer (normalt år + löpnummer)
    public Guid Id { get; set; }

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
    public override string ToString()
    {
        return $"Voucher: {Id}, Date: {Date}, Description: {Description}, Type: {Type}";
    }
}