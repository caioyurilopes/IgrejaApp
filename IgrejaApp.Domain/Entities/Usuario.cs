using IgrejaApp.Domain.DTOs.Enums;

namespace IgrejaApp.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }

    // Dados pessoais //
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

    // Cônjuge //
    public int? ConjugeId { get; set; }
    public Usuario? Conjuge { get; set; }
    public string? NomeConjuge { get; set; } = string.Empty;
    public DateTime? DataCasamento { get; set; }

    // Pais //
    public string? NomePai { get; set; } = string.Empty;
    public string? NomeMae { get; set; } = string.Empty;

    // Batismo //
    public Batismo? Batismo { get; set; }

    public DateTime DataAdmissao { get; set; }
    public string MeioAdmissao { get; set; } = string.Empty;

    // Login //
    public string? Celular { get; set; } = string.Empty;
    public string? Senha { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}