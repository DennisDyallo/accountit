using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Taxana.Backend.Infrastructure;

public class DexieStore(ILogger<DexieStore> logger, IJSRuntime js) : IDexieStore, IAsyncDisposable
{
    private bool _initialized;
    // private const string dexieJsPath = "./js/dexie-interop.iife.js"; // ts compiled version
    private const string dexieJsPath = "./js/dexie-bridge.js";

    public async Task InitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema)
    {
        if (_initialized)
            return;

        logger.LogInformation("Initializing Dexie store {dbName} with version {version} and schema {schema}", dbName, version, schema);

        await js.InvokeVoidAsync("import", dexieJsPath);
        await Task.Delay(300);

        await js.InvokeVoidAsync("dexie.init", dbName, version, schema);
        _initialized = true;

        logger.LogInformation("Dexie store initialized successfully");
    }

    public async Task DeleteDatabaseAsync(string dbName)
    {
        await js.InvokeVoidAsync("dexie.deleteDatabase", dbName);
        _initialized = false;

        logger.LogInformation("Database deleted successfully");
    }

    public async Task ResetAndInitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema)
    {
        await DeleteDatabaseAsync(dbName);
        await InitializeAsync(dbName, version, schema);
    }

    public async ValueTask AddAsync<T>(string tableName, T item)
    {
        EnsureInitialized();
        await js.InvokeVoidAsync("dexie.table.add", tableName, item);
        logger.LogInformation($"Add {tableName} ({item}))");
    }

    public async Task<T?> GetAsync<T>(string tableName, long id)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<T>("dexie.table.get", tableName, id);
        logger.LogInformation($"Get {tableName} ({result})");
        return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string tableName)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<IEnumerable<T>>("dexie.table.getAll", tableName);
        logger.LogInformation($"GetAll {tableName} ({result.Count()})");
        return result;
    }

    public async Task<IEnumerable<T>> WhereAsync<T>(string tableName, string key, object value)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<IEnumerable<T>>("dexie.table.where", tableName, key, value);
        logger.LogInformation($"Where {tableName} ({result.Count()})");
        return result;
    }

    private void EnsureInitialized()
    {
        if (!_initialized)
            throw new InvalidOperationException("Database not initialized. Call InitializeAsync first.");
    }

    public async ValueTask DisposeAsync()
    {
        // Any cleanup if needed
        await Task.CompletedTask;
    }
}