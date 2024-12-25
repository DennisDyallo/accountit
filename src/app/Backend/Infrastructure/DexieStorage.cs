using Microsoft.JSInterop;

namespace Domain.Infrastructure;

public class DexieStore : IAsyncDisposable 
{
    private readonly IJSRuntime _js;
    private bool _initialized;

    public DexieStore(IJSRuntime js)
    {
        _js = js;
    }

    public async Task InitializeAsync(string dbName, int version, IDictionary<string, string> schema)
    {
        if (_initialized)
            return;

        await _js.InvokeVoidAsync("import", "./js/dexie-interop.iife.js");
        await _js.InvokeVoidAsync("dexie.init", dbName, version, schema);
        _initialized = true;
    }

    public async Task DeleteDatabaseAsync(string dbName)
    {
        await _js.InvokeVoidAsync("dexie.deleteDatabase", dbName);
        _initialized = false;
    }

    public async Task ResetAndInitializeAsync(string dbName, IDictionary<string, string> schema, int version = 1)
    {
        await DeleteDatabaseAsync(dbName);
        await InitializeAsync(dbName, version, schema);
    }

    public async Task<long> AddAsync<T>(string tableName, T item)
    {
        EnsureInitialized();
        return await _js.InvokeAsync<long>("dexie.table.add", tableName, item);
    }

    public async Task<T?> GetAsync<T>(string tableName, long id)
    {
        EnsureInitialized();
        return await _js.InvokeAsync<T>("dexie.table.get", tableName, id);
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string tableName)
    {
        EnsureInitialized();
        return await _js.InvokeAsync<IEnumerable<T>>("dexie.table.getAll", tableName);
    }

    public async Task<IEnumerable<T>> WhereAsync<T>(string tableName, string key, object value)
    {
        EnsureInitialized();
        return await _js.InvokeAsync<IEnumerable<T>>("dexie.table.where", tableName, key, value);
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