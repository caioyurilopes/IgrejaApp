using IgrejaApp.Api.Endpoints;
using IgrejaApp.Api.Filters;

namespace IgrejaApp.Api.Extensions;

public static class AppExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGroup("v1")
            .MapAuthEndpoints()
            .AllowAnonymous()
            .AddEndpointFilter<ApiKeyAuthorizationFilter>();

        app.MapGroup("v1")
            .MapViaCepEndpoints()
            .AllowAnonymous()
            .AddEndpointFilter<ApiKeyAuthorizationFilter>();

        app.MapGroup("v1/membros")
            .MapMembrosEndpoints()
            .AddEndpointFilter<ApiKeyAuthorizationFilter>();
        return app;
    }
}