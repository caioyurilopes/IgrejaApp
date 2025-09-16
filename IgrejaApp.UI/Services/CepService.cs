namespace IgrejaApp.UI.Services;

public class CepService : ServiceBase, ICepService
{
    public CepService(HttpClient httpClient, IOptions<ApiSettings> settings) : base(httpClient, settings)
    {
    }

    public async Task<CepResponse?> GetEnderecoByCepAsync(string cep)
    {
        try
        {
            if (cep.Length != 8)
                return null;

            CepResponse? response = await GetAsync<CepResponse>($"/v1/viacep/{cep}");
            return response;
        }
        catch
        {
            return null;
        }
    }
}