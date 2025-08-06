using IgrejaApp.Domain.DTOs.Requests.Secretaria.Membros;
using IgrejaApp.Domain.DTOs.Responses;
using IgrejaApp.Domain.DTOs.Responses.Secretaria.Membros;
using IgrejaApp.Domain.Interfaces;

namespace IgrejaApp.Api.Endpoints;

public static class MembrosEndpoints
{
    public static RouteGroupBuilder MapMembrosEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllAsync);
        group.MapGet("/nomes", GetAllNomesMembrosAsync);
        group.MapPost("/", CadastrarMembroAsync);
        return group;
    }

    private static async Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync(IMembrosService membrosService)
    {
        return await membrosService.GetAllNomesMembrosAsync();
    }

    private static async Task<List<MembrosResponse>?> GetAllAsync(IMembrosService membrosService)
    {
        return await membrosService.GetAllAsync();
    }

    private static async Task<IResult> CadastrarMembroAsync(CadastrarMembroRequest request,
        IMembrosService membrosService)
    {
        await membrosService.CadastrarMembroAsync(request);
        return Results.Created($"/v1/membros", null);
    }
}