namespace Taxana.Backend.Enums;

// Kontogrupp enligt BAS (1-8)
// Kontoklasser enligt BAS Kontoplan
public enum AccountClass
{
    // Klass 1: Tillgångar
    // Class 1: Assets
    Assets = 1,

    // Klass 2: Skulder och Eget kapital
    // Class 2: Liabilities and Equity
    LiabilitiesAndEquity = 2,

    // Klass 3: Intäkter och Externa kostnader
    // Class 3: Revenue
    Revenue = 3,

    // Klass 4: Kostnader för varor, material och vissa köpta tjänster
    // Class 4: Cost of goods, materials and certain purchased services
    MaterialCosts = 4,

    // Klass 5: Övriga externa kostnader
    // Class 5: Other external costs
    ExternalCosts = 5,

    // Klass 6: Övriga externa kostnader
    // Class 6: Other external costs
    PersonnelCosts = 6,

    // Klass 7: Kostnader för personal, avskrivningar m.m.
    // Class 7: Personnel costs, depreciation, etc.
    DepreciationAndFinancials = 7,

    // Klass 8: Finansiella och andra inkomster och utgifter
    // Class 8: Financial and other income and expenses
    FinancialItemsAndTaxes = 8
}