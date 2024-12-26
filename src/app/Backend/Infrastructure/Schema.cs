namespace Taxana.Backend.Infrastructure;

public class Schema : ISchema
{
    public IReadOnlyDictionary<string, string> GetSchema() => _schema;

    private readonly IReadOnlyDictionary<string, string> _schema = new Dictionary<string, string>
    {
        ["users"] = "++id",
        ["accounts"] = "number",
        ["vouchers"] = "id",
        ["invoices"] = "++id",
        ["attachments"] = "++id",
        ["fiscalYears"] = "year"
    };
}