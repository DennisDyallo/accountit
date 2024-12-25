// Represents an account in the Swedish BAS Kontoplan
// Konto enligt BAS Kontoplan


using Taxana.Backend.Enums;
using Taxana.Backend.Helpers;

namespace Taxana.Backend.Models;

public class Account
{
    // Kontonummer
    public string Number { get; init; }

    // Kontonamn
    public string Name { get; init; }

    // Kontotyp (tillgång, skuld, etc.)
    public AccountType Type { get; init; }

    // Kontogrupp enligt BAS (1-8)
    public AccountClass Class { get; init; }

    // Momspliktigt konto
    public bool VATEligible { get; init; }

    // Saldo
    public decimal Balance { get; private set; }
    public Account(string number, string name, bool vatEligible = false)
    {
        Number = number;
        Name = name;
        VATEligible = vatEligible;
        Class = AccountClassHelper.GetAccountClass(number);
        Type = DetermineAccountType(Class);
        Balance = 0;
    }

    private static AccountType DetermineAccountType(AccountClass accountClass)
    {
        if (AccountClassHelper.IsAssetAccount(accountClass))
            return AccountType.Asset;
        if (AccountClassHelper.IsLiabilityOrEquityAccount(accountClass))
            return AccountType.Liability; // Note: This simplification might need refinement
        if (accountClass == AccountClass.Revenue)
            return AccountType.Revenue;
        return AccountType.Expense;
    }

    public void UpdateBalance(decimal amount)
    {
        Balance += amount;
    }
}