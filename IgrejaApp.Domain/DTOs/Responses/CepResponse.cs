using System.Text.Json.Serialization;

namespace IgrejaApp.Domain.DTOs.Responses;

public class CepResponse
{
    [JsonPropertyName("logradouro")] public string? Logradouro { get; set; }
    [JsonPropertyName("bairro")] public string? Bairro { get; set; }
    [JsonPropertyName("localidade")] public string? Localidade { get; set; }
    [JsonPropertyName("uf")] public string? Uf { get; set; }
    [JsonPropertyName("complemento")] public string? Complemento { get; set; }
    [JsonPropertyName("erro")] public bool? Erro { get; set; }
}