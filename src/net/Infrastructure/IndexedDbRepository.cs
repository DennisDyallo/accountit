using Microsoft.JSInterop;

namespace Infrastructure;

// Repository interface

public class IndexedDbRepository<T> : IRepository<T> where T : class
{
    private readonly IIndexedDbAccessor _indexedDbAccessor;
    
    private readonly string _storeName;

    public IndexedDbRepository(IIndexedDbAccessor indexedDbAccessor, string storeName)
    {
        _indexedDbAccessor = indexedDbAccessor;
        _storeName = storeName;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _indexedDbAccessor.GetByIdAsync<T>(id);
        return await _indexedDbAccessor.InvokeAsync<T>("indexedDb.get", _storeName, id.ToString());
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _indexedDbAccessor.InvokeAsync<IEnumerable<T>>("indexedDb.getAll", _storeName);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _indexedDbAccessor.InvokeVoidAsync("indexedDb.add", _storeName, entity);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        await _indexedDbAccessor.InvokeVoidAsync("indexedDb.put", _storeName, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _indexedDbAccessor.InvokeVoidAsync("indexedDb.delete", _storeName, id.ToString());
    }
}