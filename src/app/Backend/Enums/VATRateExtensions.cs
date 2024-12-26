

namespace Taxana.Backend.Enums;

public static class VATRateExtensions
{
    public static decimal ToDecimal(this VATRate rate) => rate switch
    {
        VATRate.Zero => 0.00m,
        VATRate.Low => 0.06m,
        VATRate.Medium => 0.12m,
        VATRate.Standard => 0.25m,
        _ => throw new ArgumentException("Invalid VAT rate")
    };
}