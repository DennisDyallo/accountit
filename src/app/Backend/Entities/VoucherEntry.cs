
// Verifikationsrad

using Domain.Enums;

namespace Domain.Entities;

public class VoucherEntry
{
    // Konto
    public Account Account { get; init; }
    
    // Debet
    public decimal Debit { get; init; }
    
    // Kredit
    public decimal Credit { get; init; }
    
    // Momssats
    public VATRate? VATRate { get; init; }
}