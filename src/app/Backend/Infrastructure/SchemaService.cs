namespace Taxana.Backend.Infrastructure;

public class SchemaService(IDexieStore dexieStore, ISchema schema) : ISchemaService
{
    private const string DbName = "taxana_db";
    private const int DbVersion = 1;

    private async Task InitializeBaseAccounts()
    {
        var accounts = DbAccountInit.GetBaseAccounts();
        var failures = new List<(string Number, string Error)>();

        foreach (var account in accounts)
        {
            try
            {
                await dexieStore.AddAsync("accounts", account);
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
        await dexieStore.InitializeAsync(DbName, DbVersion, schema.GetSchema());
        await InitializeBaseAccounts();
    }

    public async Task ResetDatabaseAsync()
    {
        await dexieStore.ResetAndInitializeAsync(DbName, DbVersion, schema.GetSchema());
        await InitializeBaseAccounts();
    }
}