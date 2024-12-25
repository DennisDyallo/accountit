
// Privata transaktioner (för NE-bilaga)



namespace Taxana.Backend.Models;

public class PrivateTransaction
{
    // Datum
    public DateTime Date { get; init; }

    // Belopp
    public decimal Amount { get; init; }

    // Transaktionstyp (uttag/insättning)
    public PrivateTransactionType Type { get; init; }

    // Beskrivning
    public string Description { get; init; }
}