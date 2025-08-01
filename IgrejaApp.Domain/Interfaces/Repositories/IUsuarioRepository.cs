using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.Entities;

namespace IgrejaApp.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByCelularAsync(string celular);
    Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync();
    Task<Usuario> CadastrarUsuarioAsync(Usuario usuario);
}