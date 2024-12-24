// Verifikation

using Domain.Enums;

namespace Domain.Entities;

public class Voucher
{
    // Verifikationsnummer (normalt år + löpnummer)
    public string Id { get; init; }
    
    // Bokföringsdatum
    public DateTime Date { get; init; }
    
    // Beskrivning/text
    public string Description { get; init; }
    
    // Verifikationsrader
    public List<VoucherEntry> Entries { get; init; }
    
    // Bilagor/underlag
    public List<Attachment> Attachments { get; init; }
    
    // Verifikationstyp
    public VoucherType Type { get; init; }
}