using System.Text.Json;

namespace IgrejaApp.UI.Utils;

public class AppConfigurationService
{
    private readonly HttpClient _httpClient;

    public ApiSettings Settings { get; private set; } = new();

    public AppConfigurationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task LoadAsync()
    {
        var response = await _httpClient.GetAsync("appsettings.json");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Settings = JsonSerializer.Deserialize<ApiSettings>(json) ?? new();
        }
    }
}