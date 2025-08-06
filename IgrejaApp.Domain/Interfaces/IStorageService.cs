namespace IgrejaApp.Domain.Interfaces;

public interface IStorageService
{
    Task SetItemAsync<T>(string key, T value);
    Task<T?> GetItemAsync<T>(string key);
    Task RemoverItemAsync(string key);
    Task ClearAsync();
    Task<bool> ContainsKeyAsync(string key);
}