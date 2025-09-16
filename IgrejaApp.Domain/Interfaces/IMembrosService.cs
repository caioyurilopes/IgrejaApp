namespace IgrejaApp.Domain.Interfaces;

public interface IMembrosService
{
    Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync();
    Task<List<MembrosResponse>?> GetAllAsync();
    Task<VisualizarMembroResponse?> GetByIdAsync(int id); 
    Task CadastrarMembroAsync(CadastrarMembroRequest request);
}