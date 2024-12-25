
// Anläggningstillgång

namespace Taxana.Backend.Models;

public class Asset
{
    public string Id { get; init; }

    // Beskrivning
    public string Description { get; init; }

    // Inköpspris
    public decimal PurchasePrice { get; init; }

    // Inköpsdatum
    public DateTime PurchaseDate { get; init; }

    // Avskrivningsår
    public int DepreciationYears { get; init; }

    // Restvärde
    public decimal ResidualValue { get; init; }

    // Transaktioner kopplade till tillgången
    public List<AssetTransaction> Transactions { get; init; }
}