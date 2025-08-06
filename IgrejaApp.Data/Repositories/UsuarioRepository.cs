using IgrejaApp.Data.Context;
using IgrejaApp.Domain.DTOs.Enums;
using IgrejaApp.Domain.Entities;
using IgrejaApp.Domain.Interfaces.Repositories;
using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.DTOs.Responses.Secretaria.Membros;
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

    public async Task<List<MembrosResponse>?> GetAllAsync()
    {
        return await context.Usuarios.Where(u => u.TipoUsuario != TipoUsuario.Dev).Select(u => new MembrosResponse
        {
            Id = u.Id,
            NomeCompleto = u.NomeCompleto,
            Telefone = u.Telefone,
            EstadoCivil = u.EstadoCivil,
            Ativo = u.Ativo
        }).ToListAsync();
    }

    public async Task<Usuario> CadastrarUsuarioAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }
}