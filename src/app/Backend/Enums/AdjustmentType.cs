// Typ av bokslutsjustering
namespace Domain.Enums;

public enum AdjustmentType
{
    // Avskrivning
    Depreciation,
    
    // Upplupet
    Accrual,
    
    // Förutbetalt
    Prepayment,
    
    // Momsjustering
    VATAdjustment,
    
    // Övrigt
    Other
}