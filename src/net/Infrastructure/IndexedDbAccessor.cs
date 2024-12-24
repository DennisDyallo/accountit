using Microsoft.JSInterop;

namespace Infrastructure;

public class IndexedDbAccessor : IAsyncDisposable, IIndexedDbAccessor
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;

    /// <summary>
    /// Creates an instance of <see cref="LocalStorageAccessor"/>.
    /// </summary>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/> to use.</param>
    public IndexedDbAccessor(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }


    /// <summary>
    /// Ensures that the JavaScript object reference for local storage access is created.
    /// </summary>
    /// <remarks>
    /// If the JavaScript object reference is not yet created, this method imports the 
    /// "LocalStorageAccessor.js" module and assigns the reference to `_accessorJsRef`.
    /// </remarks>
    private async Task WaitForReference()
    {
        if (_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef =
                new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/IndexedDbAccessor.js"));
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }

    public async Task<T> GetByIdAsync<T>(string storeName, Guid id)
    {
        await WaitForReference();
        return await _jsRuntime.InvokeAsync<T>("indexedDb.getAll", storeName, id.ToString());
    }
    //
    // public async Task<T> GetAllAsync<T>(string storeName)
    // {
    //     await WaitForReference();
    //     return await _jsRuntime.InvokeAsync<T>("indexedDb.get", storeName, id.ToString());
    // }
    //
    // public async Task SetValueAsync<T>(string key, T value)
    // {
    //     await WaitForReference();
    //     await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
    // }
    //
    // public async Task Clear()
    // {
    //     await WaitForReference();
    //     await _accessorJsRef.Value.InvokeVoidAsync("clear");
    // }
    //
    // public async Task RemoveAsync(string key)
    // {
    //     await WaitForReference();
    //     await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
    // }
}

public interface IIndexedDbAccessor
{
    public Task<T> GetByIdAsync<T>(Guid id);

    public Task<IEnumerable<T>> GetAllAsync<T>();

    // public async Task<T> AddAsync(T entity)
    // {
    //     return entity;
    // }
    //
    // public async Task UpdateAsync(T entity)
    // {
    //     await _indexedDbAccessor.InvokeVoidAsync("indexedDb.put", _storeName, entity);
    // }
    //
    // public async Task DeleteAsync(Guid id)
    // {
    //     await _indexedDbAccessor.InvokeVoidAsync("indexedDb.delete", _storeName, id.ToString());
    // }
}