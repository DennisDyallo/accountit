
using Taxana.Backend.Enums;

namespace Taxana.Backend.Models;

// Privata transaktioner (för NE-bilaga)
// Eget "UTTAG" eller "INSATTNING"

public class PrivateTransaction
{
    // Datum
    public DateTime Date { get; init; }

    // Belopp
    public decimal Amount { get; init; }

    // Transaktionstyp (uttag/insättning)
    public PrivateTransactionType Type { get; init; }

    // Beskrivning
    public required string Description { get; init; }
}