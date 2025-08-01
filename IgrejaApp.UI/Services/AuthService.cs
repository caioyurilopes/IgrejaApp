using IgrejaApp.Domain.DTOs.Requests;
using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.Interfaces;
using IgrejaApp.UI.Utils;
using Microsoft.Extensions.Options;

namespace IgrejaApp.UI.Services;

public class AuthService : ServiceBase, IAuthService
{
    private readonly string _url = "auth/";

    public AuthService(HttpClient httpClient, IOptions<ApiSettings> settings) : base(httpClient, settings)
    {
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        string url = _url + "login";
        return await PostAsync<AuthResponse>(url, request);
    }
}