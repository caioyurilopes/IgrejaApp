namespace IgrejaApp.Api.Services;

public class AuthService(IUsuarioRepository usuarioRepository, TokenService tokenService) : IAuthService
{
    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        Usuario? usuario = await usuarioRepository.GetByCelularAsync(request.Celular);
        if (usuario is null)
            return new AuthResponse
            {
                Succeeded = false,
                Message = "401"
            };

        bool senha = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);
        if (!senha)
            return new AuthResponse
            {
                Succeeded = false,
                Message = "403"
            };

        var response = tokenService.GenerateToken(usuario);
        return response;
    }
}