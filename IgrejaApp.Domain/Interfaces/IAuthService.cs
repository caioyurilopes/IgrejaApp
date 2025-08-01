using IgrejaApp.Domain.DTOs.Requests;
using IgrejaApp.Domain.DTOs.Responses;

namespace IgrejaApp.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(LoginRequest request);
}