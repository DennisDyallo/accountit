namespace Taxana.Backend.Models;
// Typ av tillgångstransaktion
// Type of asset transaction
public enum AssetTransactionType
{
    // Inköp
    // Purchase
    Purchase,

    // Försäljning
    // Sale
    Sale,

    // Avskrivning
    // Depreciation
    Depreciation,

    // Uppskrivning
    // Write-up
    WriteUp,

    // Nedskrivning
    // Write-down
    WriteDown,

    // Utrangering
    // Disposal
    Disposal,

    // Delförsäljning
    // Partial sale
    PartialSale,

    // Förbättring/tillbyggnad
    // Improvement/extension
    Improvement
}