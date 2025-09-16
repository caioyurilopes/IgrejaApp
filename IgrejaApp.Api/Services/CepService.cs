namespace IgrejaApp.Api.Services;

public class CepService : ICepService
{
    private readonly HttpClient _httpClient;

    public CepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CepResponse?> GetEnderecoByCepAsync(string cep)
    {
        if (cep.Length != 8) return null;

        try
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            CepResponse? response = await _httpClient.GetFromJsonAsync<CepResponse>(url);
            return response?.Erro == true ? null : response;
        }
        catch
        {
            return null;
        }
    }
}