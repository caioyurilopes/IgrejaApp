namespace IgrejaApp.UI.Services;

public abstract class ServiceBase
{
    protected readonly HttpClient HttpClient;

    protected ServiceBase(HttpClient httpClient, IOptions<ApiSettings> settings)
    {
        HttpClient = httpClient;
        var settings1 = settings.Value;

        if (!HttpClient.DefaultRequestHeaders.Contains("X-Api-Key"))
            HttpClient.DefaultRequestHeaders.Add("X-Api-Key", settings1.ApiKey);
    }

    protected async Task<T?> GetAsync<T>(string url) where T : class, new()
    {
        try
        {
            var response = await HttpClient.GetAsync(url);
            string resultJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(resultJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                if (typeof(T) == typeof(AuthResponse))
                {
                    AuthResponse authResponse = new AuthResponse
                    {
                        Message = ((int)response.StatusCode).ToString()
                    };
                    return authResponse as T;
                }

                await LogError(resultJson, "Erro na API (GET)");
                return default;
            }
        }
        catch (Exception ex)
        {
            await LogError(ex.ToString(), "Exceção no GetAsync");
            return default;
        }
    }

    protected async Task<bool> PostAsync(string url, object data)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                return true;

            string resultJson = await response.Content.ReadAsStringAsync();
            await LogError(resultJson, "Erro na API (PostAsync sem retorno)");
            return false;
        }
        catch (Exception ex)
        {
            await LogError(ex.ToString(), "Exceção no PostAsync sem retorno");
            return false;
        }
    }

    protected async Task<T?> PostAsync<T>(string url, object data) where T : class, new()
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, content);

            string resultJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(resultJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                if (typeof(T) == typeof(AuthResponse))
                {
                    AuthResponse authResponse = new AuthResponse
                    {
                        Message = ((int)response.StatusCode).ToString()
                    };
                    return authResponse as T;
                }

                await LogError(resultJson, "Erro na API");
                return default;
            }
        }
        catch (Exception ex)
        {
            await LogError(ex.ToString(), "Exceção no PostAsync");
            return default;
        }
    }

    private async Task LogError(string message, string title)
    {
        LogRequest log = new LogRequest
        {
            Message = message,
            Title = title,
            CreateDate = DateTimeOffset.Now,
            UserId = null,
            Version = "1.0.0"
        };

        string logJson = JsonSerializer.Serialize(log);
        var content = new StringContent(logJson, Encoding.UTF8, "application/json");

        try
        {
            await HttpClient.PostAsync("logs", content);
        }
        catch
        {
        }
    }
}