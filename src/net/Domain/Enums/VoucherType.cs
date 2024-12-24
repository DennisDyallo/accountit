// Verifikationstyp
namespace Domain.Enums;

public enum VoucherType
{
    // Inköp
    Purchase,
    
    // Försäljning
    Sale,
    
    // Banktransaktion
    Bank,
    
    // Kontanttransaktion
    Cash,
    
    // Justering
    Adjustment,
    
    // Årsbokslutstransaktion
    YearEnd
}