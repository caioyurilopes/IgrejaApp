namespace IgrejaApp.Api.Filters;

public class ApiKeyAuthorizationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.HttpContext.Request;

        if (!request.Headers.TryGetValue("X-Api-Key", out var extractedApiKey) ||
            extractedApiKey != "Ltfof@192")
        {
            return Results.Unauthorized();
        }

        return await next(context);
    }
}