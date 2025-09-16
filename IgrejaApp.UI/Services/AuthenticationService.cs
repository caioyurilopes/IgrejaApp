namespace IgrejaApp.UI.Services;

public class AuthenticationService(IStorageService storageService) : IAuthenticationService
{
    private readonly IStorageService _storageService = storageService;
    
    public async Task<bool> IsLoggedInAsync()
    {
        try
        {
            var token = await _storageService.GetItemAsync<string>("token");
            if (string.IsNullOrWhiteSpace(token))
                return false;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            return jwtToken.ValidTo > DateTime.UtcNow;
        }
        catch
        {
            return false;
        }
    }

    public async Task LogoutAsync()
    {
        await _storageService.ClearAsync();
    }
}