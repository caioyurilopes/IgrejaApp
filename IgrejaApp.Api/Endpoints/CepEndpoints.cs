namespace IgrejaApp.Api.Endpoints;

public static class CepEndpoints
{
    public static RouteGroupBuilder MapViaCepEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/viacep/{cep}", async ([FromRoute] string cep, [FromServices] ICepService cepService) =>
        {
            try
            {
                CepResponse? response = await cepService.GetEnderecoByCepAsync(cep);
                return response is null ? Results.NotFound() : Results.Ok(response);
            }
            catch
            {
                return Results.Problem("Erro ao consultar o CEP.");
            }
        });

        return group;
    }
}