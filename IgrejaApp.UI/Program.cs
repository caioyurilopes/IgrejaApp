using IgrejaApp.Domain.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using IgrejaApp.UI;
using IgrejaApp.UI.Services;
using IgrejaApp.UI.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient base para carregar o appsettings.json (pode ser usado no AppConfigurationService)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Criar instância do serviço de configuração (sem registrar ainda)
var configService = new AppConfigurationService(
    builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>()
);

// Carregar as configurações async ANTES do Build
await configService.LoadAsync();

// Registrar singleton do serviço de configuração
builder.Services.AddSingleton(configService);

// Registrar HttpClient para API com base na configuração carregada
builder.Services.AddScoped(sp =>
{
    var apiSettings = configService.Settings;

    var client = new HttpClient
    {
        BaseAddress = new Uri(apiSettings.BaseUrl)
    };
    client.DefaultRequestHeaders.Add("X-Api-Key", apiSettings.ApiKey);

    return client;
});

// Registrar serviços da aplicação
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMembrosService, MembrosService>();
builder.Services.AddScoped<ICepService, CepService>();

// Construir host e rodar app
var host = builder.Build();

await host.RunAsync();