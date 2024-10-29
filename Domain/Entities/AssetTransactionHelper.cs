using Domain.Enums;

namespace Domain.Entities;

// Hjälpklass för vanliga beräkningar
// Helper class for common calculations
public static class AssetTransactionHelper
{
    // Beräkna årlig avskrivning
    // Calculate yearly depreciation
    public static decimal CalculateYearlyDepreciation(
        decimal purchasePrice,
        decimal residualValue,
        int depreciationYears)
    {
        return (purchasePrice - residualValue) / depreciationYears;
    }
    
    // Beräkna momsen för ett inköp
    // Calculate VAT for a purchase
    public static decimal CalculateVAT(decimal amount, VATRate rate)
    {
        return amount * (decimal)rate / 100m;
    }
    
    // Beräkna avdragsgill del baserad på företagsanvändning
    // Calculate deductible portion based on business usage
    public static decimal CalculateDeductibleAmount(
        decimal amount, 
        decimal businessUsagePercentage)
    {
        return amount * (businessUsagePercentage / 100m);
    }
}