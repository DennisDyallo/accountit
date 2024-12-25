using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

// Represents a transaction related to a fixed asset (anläggningstillgång)
public class AssetTransaction
{
    // Unikt ID för transaktionen
    // Unique ID for the transaction
    public string Id { get; init; }

    // Koppling till huvudboken
    // Reference to the general ledger voucher
    public string VoucherId { get; init; }

    // Transaktionsdatum
    // Transaction date
    public DateTime Date { get; init; }

    // Transaktionstyp
    // Transaction type
    public AssetTransactionType Type { get; init; }

    // Belopp
    // Amount
    public decimal Amount { get; init; }

    // Eventuellt restvärde efter transaktionen
    // Residual value after transaction (if applicable)
    public decimal? ResidualValue { get; init; }

    // Beskrivning
    // Description
    public string Description { get; init; }

    // Momssats om tillämpligt
    // VAT rate if applicable
    public VATRate? VATRate { get; init; }

    // Momsbelopp
    // VAT amount
    public decimal? VATAmount { get; init; }

    // För delvis privat användning
    // For partially private use
    public decimal? PrivateUsagePercentage { get; init; }
}