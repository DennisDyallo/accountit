namespace Taxana.Backend.Infrastructure;

public interface ISchemaService
{
    public Task InitializeAsync();

    public Task ResetDatabaseAsync();
}

public class TaxanaSchemaService(IDexieStore dexieStore) : ISchemaService
{
    private readonly IDexieStore _dexieStore = dexieStore;
    private const string DbName = "taxana_db";
    private const int DbVersion = 1;

    private IReadOnlyDictionary<string, string> Schema = new Dictionary<string, string>
    {
        // Schema definition based on app-spec.md
        ["accounts"] = "number",
        ["transactions"] = "++id",
        ["invoices"] = "++id",
        ["attachments"] = "++id",
        ["settings"] = "id",
        ["fiscalYears"] = "year"
    };

    public async Task InitializeAsync() => await _dexieStore.InitializeAsync(DbName, DbVersion, Schema);

    public async Task ResetDatabaseAsync() => await _dexieStore.ResetAndInitializeAsync(DbName, DbVersion, Schema);
}