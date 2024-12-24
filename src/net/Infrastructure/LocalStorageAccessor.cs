using Microsoft.JSInterop;

namespace Infrastructure;

public class LocalStorageAccessor : IAsyncDisposable, ILocalStorageAccessor
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;

    /// <summary>
    /// Creates an instance of <see cref="LocalStorageAccessor"/>.
    /// </summary>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/> to use.</param>
    public LocalStorageAccessor(IJSRuntime jsRuntime)
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
                new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/LocalStorageAccessor.js"));
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }

    public async Task<T> GetValueAsync<T>(string key)
    {
        await WaitForReference();
        var result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);

        return result;
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task Clear()
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("clear");
    }

    public async Task RemoveAsync(string key)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
    }
}