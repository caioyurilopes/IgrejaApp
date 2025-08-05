using IgrejaApp.Domain.DTOs.Enums;

namespace IgrejaApp.Domain.DTOs.Responses.Secretaria.Membros;

public class MembrosResponse
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public EstadoCivil EstadoCivil { get; set; }
    public bool Ativo { get; set; }
}