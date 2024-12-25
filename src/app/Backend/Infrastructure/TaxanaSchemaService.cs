namespace Taxana.Backend.Infrastructure;

public interface ISchemaService
{
    public Task InitializeAsync();
    public Task ResetDatabaseAsync();
}

public class TaxanaSchemaService : ISchemaService
{
    private readonly IDexieStore _dexieStore;
    private const string DbName = "taxana_db";
    private const int DbVersion = 1;

    public TaxanaSchemaService(IDexieStore dexieStore)
    {
        _dexieStore = dexieStore;
    }

    private IReadOnlyDictionary<string, string> Schema = new Dictionary<string, string>
    {
        ["accounts"] = "number",
        ["transactions"] = "++id",
        ["invoices"] = "++id",
        ["attachments"] = "++id",
        ["settings"] = "id",
        ["fiscalYears"] = "year"
    };

    private async Task InitializeBaseAccounts()
    {
        var accounts = DbAccountInit.GetBaseAccounts();
        var failures = new List<(string Number, string Error)>();

        foreach (var account in accounts)
        {
            try
            {
                await _dexieStore.AddAsync("accounts", account);
            }
            catch (Exception ex)
            {
                failures.Add((account.Number, ex.Message));
            }
        }

        if (failures.Any())
        {
            // In a production environment, this should be properly logged
            var errorMessage = string.Join("\n", failures.Select(f => $"Account {f.Number}: {f.Error}"));
            throw new InvalidOperationException($"Failed to initialize some accounts:\n{errorMessage}");
        }
    }

    public async Task InitializeAsync()
    {
        await _dexieStore.InitializeAsync(DbName, DbVersion, Schema);
        await InitializeBaseAccounts();
    }

    public async Task ResetDatabaseAsync()
    {
        await _dexieStore.ResetAndInitializeAsync(DbName, DbVersion, Schema);
        await InitializeBaseAccounts();
    }
}