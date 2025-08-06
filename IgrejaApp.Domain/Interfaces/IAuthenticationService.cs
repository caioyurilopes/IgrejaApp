namespace IgrejaApp.Domain.Interfaces;

public interface IAuthenticationService
{
    Task<bool> IsLoggedInAsync();
    Task LogoutAsync();
}