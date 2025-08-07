using IgrejaApp.Domain.DTOs.Responses.Secretaria.Membros;
using IgrejaApp.Domain.Entities;

namespace IgrejaApp.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario?> GetByCelularAsync(string celular);
    Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync();
    Task<List<MembrosResponse>?> GetAllAsync();
    Task<Usuario> CadastrarUsuarioAsync(Usuario usuario);
}