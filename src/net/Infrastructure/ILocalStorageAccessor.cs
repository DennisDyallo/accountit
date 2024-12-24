namespace Infrastructure;

public interface ILocalStorageAccessor
{
    ValueTask DisposeAsync();
    Task<T> GetValueAsync<T>(string key);
    Task SetValueAsync<T>(string key, T value);
    Task Clear();
    Task RemoveAsync(string key);
}