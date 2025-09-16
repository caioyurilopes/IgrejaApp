namespace IgrejaApp.UI.Services;

public class StorageService(ILocalStorageService localStorage) : IStorageService
{
    private readonly ILocalStorageService _localStorage = localStorage;

    public async Task SetItemAsync<T>(string key, T value)
    {
        await _localStorage.SetItemAsync(key, value);
    }

    public async Task<T?> GetItemAsync<T>(string key)
    {
        return await _localStorage.GetItemAsync<T>(key);
    }

    public async Task RemoverItemAsync(string key)
    {
        await _localStorage.RemoveItemAsync(key);
    }

    public async Task ClearAsync()
    {
        await _localStorage.ClearAsync();
    }

    public async Task<bool> ContainsKeyAsync(string key)
    {
        return await _localStorage.ContainKeyAsync(key);
    }
}