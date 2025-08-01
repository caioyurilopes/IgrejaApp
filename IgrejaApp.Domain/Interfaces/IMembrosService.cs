using IgrejaApp.Domain.DTOs.Requests.Secretaria.Membros;
using IgrejaApp.Domain.DTOs.Responses;

namespace IgrejaApp.Domain.Interfaces;

public interface IMembrosService
{
    Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync();
    Task CadastrarMembroAsync(CadastrarMembroRequest request);
}