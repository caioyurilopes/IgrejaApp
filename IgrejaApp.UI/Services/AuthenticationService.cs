using IgrejaApp.Domain.Interfaces;

namespace IgrejaApp.UI.Services;

public class AuthenticationService(IStorageService storageService) : IAuthenticationService
{
    private readonly IStorageService _storageService = storageService;
    
    public async Task<bool> IsLoggedInAsync()
    {
        var token = await _storageService.GetItemAsync<string>("token");
        return !string.IsNullOrWhiteSpace(token);
    }

    public async Task LogoutAsync()
    {
        await _storageService.ClearAsync();
    }
}