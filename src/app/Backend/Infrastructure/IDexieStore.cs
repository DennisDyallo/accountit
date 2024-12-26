namespace Taxana.Backend.Infrastructure;

public interface IDexieStore
{
    public Task InitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema);

    public Task DeleteDatabaseAsync(string dbName);

    public Task ResetAndInitializeAsync(string dbName, int version, IReadOnlyDictionary<string, string> schema);

    public ValueTask AddAsync<T>(string tableName, T item);

    public Task<T?> GetAsync<T>(string tableName, long id);

    public Task<IEnumerable<T>> GetAllAsync<T>(string tableName);

    public Task<IEnumerable<T>> WhereAsync<T>(string tableName, string key, object value);
}