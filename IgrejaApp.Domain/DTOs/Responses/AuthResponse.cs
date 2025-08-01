namespace IgrejaApp.Domain.DTOs.Responses;

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public List<AuthClaim> Claims { get; set; } = new();
    public bool Succeeded { get; set; }
}

public class AuthClaim
{
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}