// Verifikationstyp
namespace Taxana.Backend.Enums;

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