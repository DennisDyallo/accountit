using Domain.Enums;

namespace Domain.Helpers
{
    public static class AccountClassHelper
    {
        /// <summary>
        /// Determines the account class based on the first digit of the account number.
        /// </summary>
        /// <param name="accountNumber">The account number as a string.</param>
        /// <returns>The corresponding <see cref="AccountClass"/> for the given account number.</returns>
        /// <exception cref="ArgumentException">Thrown if the account number is null, empty, or does not correspond to a valid account class.</exception>
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