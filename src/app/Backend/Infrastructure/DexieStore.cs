using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Taxana.Backend.Infrastructure;

public interface IDexieStore
{
    public Task InitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema);

    public Task DeleteDatabaseAsync(string dbName);

    public Task ResetAndInitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema);

    public Task<long> AddAsync<T>(string tableName, T item);

    public Task<T?> GetAsync<T>(string tableName, long id);

    public Task<IEnumerable<T>> GetAllAsync<T>(string tableName);

    public Task<IEnumerable<T>> WhereAsync<T>(string tableName, string key, object value);
}

public class DexieStore(ILogger<DexieStore> logger, IJSRuntime js) : IDexieStore, IAsyncDisposable
{
    private bool _initialized;

    public async Task InitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema)
    {
        if (_initialized)
            return;

        logger.LogDebug("Initializing Dexie store {dbName} with version {version} and schema {schema}", dbName, version, schema);

        await js.InvokeVoidAsync("import", "./js/dexie-interop.iife.js");
        await Task.Delay(300);

        await js.InvokeVoidAsync("dexie.init", dbName, version, schema);
        _initialized = true;

        logger.LogInformation("Dexie store initialized successfully");
    }

    public async Task DeleteDatabaseAsync(string dbName)
    {
        await js.InvokeVoidAsync("dexie.deleteDatabase", dbName);
        _initialized = false;

        logger.LogDebug("Database deleted successfully");
    }

    public async Task ResetAndInitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema)
    {
        await DeleteDatabaseAsync(dbName);
        await InitializeAsync(dbName, version, schema);
    }

    public async Task<long> AddAsync<T>(string tableName, T item)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<long>("dexie.table.add", tableName, item);
        logger.LogDebug($"Add {tableName} ({result})");
        return result;
    }

    public async Task<T?> GetAsync<T>(string tableName, long id)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<T>("dexie.table.get", tableName, id);
        logger.LogDebug($"Get {tableName} ({result})");
        return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string tableName)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<IEnumerable<T>>("dexie.table.getAll", tableName);
        logger.LogDebug($"GetAll {tableName} ({result.Count()})");
        return result;
    }

    public async Task<IEnumerable<T>> WhereAsync<T>(string tableName, string key, object value)
    {
        EnsureInitialized();
        var result = await js.InvokeAsync<IEnumerable<T>>("dexie.table.where", tableName, key, value);
        logger.LogDebug($"Where {tableName} ({result.Count()})");
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
    }
}