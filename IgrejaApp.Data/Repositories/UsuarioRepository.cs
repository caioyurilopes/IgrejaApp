using IgrejaApp.Data.Context;
using IgrejaApp.Domain.Entities;
using IgrejaApp.Domain.Interfaces.Repositories;
using IgrejaApp.Domain.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

namespace IgrejaApp.Data.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public async Task<Usuario?> GetByCelularAsync(string celular)
    {
        return await context.Usuarios.FirstOrDefaultAsync(u => u.Celular == celular);
    }

    public async Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync()
    {
        return await context.Usuarios
            .Select(u => new NomesMembrosResponse { Id = u.Id, Nome = u.NomeCompleto })
            .ToListAsync();
    }

    public async Task<Usuario> CadastrarUsuarioAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }
}