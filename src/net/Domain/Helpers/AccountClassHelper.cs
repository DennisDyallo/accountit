using Domain.Enums;

namespace Domain.Helpers
{
    public static class AccountClassHelper
    {
        public static AccountClass GetAccountClass(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber) || accountNumber.Length < 1)
                throw new ArgumentException("Invalid account number", nameof(accountNumber));

            int firstDigit = int.Parse(accountNumber[0].ToString());
            
            return firstDigit switch
            {
                1 => AccountClass.Assets,
                2 => AccountClass.LiabilitiesAndEquity,
                3 => AccountClass.Revenue,
                4 => AccountClass.MaterialCosts,
                5 => AccountClass.ExternalCosts,
                6 => AccountClass.PersonnelCosts,
                7 => AccountClass.DepreciationAndFinancials,
                8 => AccountClass.FinancialItemsAndTaxes,
                _ => throw new ArgumentException($"Invalid account class: {firstDigit}")
            };
        }

        public static bool IsIncomeStatementAccount(AccountClass accountClass) =>
            accountClass >= AccountClass.Revenue;

        public static bool IsBalanceSheetAccount(AccountClass accountClass) =>
            accountClass <= AccountClass.LiabilitiesAndEquity;

        public static bool IsAssetAccount(AccountClass accountClass) =>
            accountClass == AccountClass.Assets;

        public static bool IsLiabilityOrEquityAccount(AccountClass accountClass) =>
            accountClass == AccountClass.LiabilitiesAndEquity;
    }
}
