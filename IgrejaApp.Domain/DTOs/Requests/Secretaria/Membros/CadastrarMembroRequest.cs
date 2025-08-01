using IgrejaApp.Domain.DTOs.Enums;

namespace IgrejaApp.Domain.DTOs.Requests.Secretaria.Membros;

public class CadastrarMembroRequest
{
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
    public string? NomeConjuge { get; set; }
    public DateTime? DataCasamento { get; set; }

    // Pais //
    public string? NomePai { get; set; } = string.Empty;
    public string? NomeMae { get; set; } = string.Empty;

    // Batismo //
    public DateTime? DataBatismo { get; set; }
    public string? IgrejaBatismo { get; set; } = string.Empty;
    public int? PastorBatismoId { get; set; }
    public string? PastorBatismoNomeManual { get; set; } = string.Empty;

    // Dados administrativos //
    public DateTime DataAdmissao { get; set; }
    public string MeioAdmissao { get; set; } = string.Empty;

    // Login //
    public string? Celular { get; set; } = string.Empty;
    public string? Senha { get; set; } = string.Empty;
}