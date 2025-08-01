using IgrejaApp.Domain.DTOs.Requests.Secretaria.Membros;
using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.Entities;
using IgrejaApp.Domain.Interfaces;
using IgrejaApp.Domain.Interfaces.Repositories;
using IgrejaApp.Domain.Mappers;

namespace IgrejaApp.Api.Services;

public class MembrosService(IUsuarioRepository usuarioRepository) : IMembrosService
{
    public async Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync()
    {
        return await usuarioRepository.GetAllNomesMembrosAsync();
    }

    public async Task CadastrarMembroAsync(CadastrarMembroRequest request)
    {
        Usuario usuario = request.ToEntity();
        await usuarioRepository.CadastrarUsuarioAsync(usuario);
    }
}