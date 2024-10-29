using Microsoft.JSInterop;

namespace Infrastructure;

// Repository interface
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}

public class IndexedDbRepository<T> : IRepository<T> where T : class
{
    private readonly IJSRuntime _jsRuntime;
    private readonly string _storeName;

    public IndexedDbRepository(IJSRuntime jsRuntime, string storeName)
    {
        _jsRuntime = jsRuntime;
        _storeName = storeName;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _jsRuntime.InvokeAsync<T>("indexedDb.get", _storeName, id.ToString());
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _jsRuntime.InvokeAsync<IEnumerable<T>>("indexedDb.getAll", _storeName);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _jsRuntime.InvokeVoidAsync("indexedDb.add", _storeName, entity);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        await _jsRuntime.InvokeVoidAsync("indexedDb.put", _storeName, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _jsRuntime.InvokeVoidAsync("indexedDb.delete", _storeName, id.ToString());
    }
}