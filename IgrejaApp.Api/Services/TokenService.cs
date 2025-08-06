using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IgrejaApp.Api.Settings;
using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IgrejaApp.Api.Services;

public class TokenService(IOptions<JwtSettings> jwtSettings)
{
    private readonly JwtSettings _jwt = jwtSettings.Value;

    public AuthResponse GenerateToken(Usuario user)
    {
        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(_jwt.ExpirationMinutes);
        var notBefore = now.AddSeconds(-1);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new("Id", user.Id.ToString()),
            new("Celular", user.Celular!),
            new("Nome", user.NomeCompleto),
        };

        if (user.TipoUsuario != null)
        {
            claims.Add(new(ClaimTypes.Role, user.TipoUsuario.ToString()));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: notBefore,
            expires: expires,
            signingCredentials: creds
        );

        return new AuthResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = GenerateRefreshToken(),
            IssueDate = now,
            ExpireDate = expires,
            Claims = claims.Select(c => new AuthClaim { Type = c.Type, Value = c.Value }).ToList(),
            Succeeded = true
        };
    }

    private static string GenerateRefreshToken()
    {
        var bytes = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}