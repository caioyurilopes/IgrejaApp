namespace IgrejaApp.Api.Services;

public class MembrosService(IUsuarioRepository usuarioRepository) : IMembrosService
{
    public async Task<List<NomesMembrosResponse>?> GetAllNomesMembrosAsync()
    {
        return await usuarioRepository.GetAllNomesMembrosAsync();
    }

    public async Task<List<MembrosResponse>?> GetAllAsync()
    {
        return await usuarioRepository.GetAllAsync();
    }

    public async Task<VisualizarMembroResponse?> GetByIdAsync(int id)
    {
        Usuario? usuario = await usuarioRepository.GetByIdAsync(id);
        if (usuario == null) return null;

        VisualizarMembroResponse response = usuario.ToResponse();
        return response;
    }

    public async Task CadastrarMembroAsync(CadastrarMembroRequest request)
    {
        Usuario usuario = request.ToEntity();
        await usuarioRepository.CadastrarUsuarioAsync(usuario);
    }
}