using IgrejaApp.Domain.DTOs.Requests.Secretaria.Membros;
using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.DTOs.Responses.Secretaria.Membros;
using IgrejaApp.Domain.Interfaces;
using IgrejaApp.UI.Utils;
using Microsoft.Extensions.Options;

namespace IgrejaApp.UI.Services;

public class MembrosService : ServiceBase, IMembrosService
{
    private readonly string _url = "membros";

    public MembrosService(HttpClient httpClient, IOptions<ApiSettings> settings) : base(httpClient, settings)
    {
    }

    public async Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync()
    {
        string url = _url + "/nomes";
        return (await GetAsync<List<NomesMembrosResponse>>(url));
    }

    public async Task<List<MembrosResponse>?> GetAllAsync()
    {
        return await GetAsync<List<MembrosResponse>>(_url);
    }

    public async Task CadastrarMembroAsync(CadastrarMembroRequest request)
    {
        await PostAsync(_url, request);
    }
}