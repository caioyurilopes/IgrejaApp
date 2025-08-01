using IgrejaApp.Domain.DTOs.Responses;

namespace IgrejaApp.Domain.Interfaces;

public interface ICepService
{
    Task<CepResponse?> GetEnderecoByCepAsync(string cep);
}