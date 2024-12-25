// Typ av bokslutsjustering
namespace Taxana.Backend.Enums;

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