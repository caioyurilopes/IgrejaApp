using IgrejaApp.Domain.DTOs.Enums;
using IgrejaApp.Domain.Entities;

namespace IgrejaApp.Domain.DTOs.Responses.Secretaria.Membros;

public class VisualizarMembroResponse
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string? Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Uf { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string? Naturalidade { get; set; } = string.Empty;
    public Genero Genero { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    public int? ConjugeId { get; set; }
    public ConjugeResponse? Conjuge { get; set; }

    public string? NomePai { get; set; } = string.Empty;
    public string? NomeMae { get; set; } = string.Empty;

    public BatismoResponse? Batismo { get; set; }
}