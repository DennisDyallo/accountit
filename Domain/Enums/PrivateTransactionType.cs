// Typ av privat transaktion
namespace Domain.Enums;

public enum PrivateTransactionType
{
    // Uttag
    Withdrawal,
    
    // Insättning
    Deposit,
    
    // Privat användning av företagets tillgångar
    PrivateAssetUse,
    
    // Företagets användning av privata tillgångar
    BusinessAssetUse
}