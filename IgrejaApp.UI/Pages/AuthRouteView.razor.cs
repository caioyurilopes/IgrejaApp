using IgrejaApp.Domain.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IgrejaApp.UI.Pages;

public partial class AuthRouteView : ComponentBase, IDisposable
{
    [Parameter] public RouteData RouteData { get; set; } = default!;
    [Parameter] public Type? DefaultLayout { get; set; }

    [Inject] private NavigationManager Navigation { get; set; } = default!;
    [Inject] private IAuthenticationService AuthService { get; set; } = default!;

    private bool _isAuthenticated;
    private bool _checkingAuth = true;
    private int _seconds = 10;
    private Timer? _timer;

    private static readonly string[] PublicRoutes = new[]
    {
        "/"
    };

    protected override async Task OnInitializedAsync()
    {
        string currentUrl = "/" + Navigation.ToBaseRelativePath(Navigation.Uri).ToLower();

        if (PublicRoutes.Contains(currentUrl))
        {
            _isAuthenticated = true;
        }
        else
        {
            _isAuthenticated = await AuthService.IsLoggedInAsync();
        }

        _checkingAuth = false;

        if (!_isAuthenticated && !PublicRoutes.Contains(currentUrl))
        {
            StartCountdown();
        }
    }

    private void StartCountdown()
    {
        _timer = new Timer(async _ =>
        {
            if (_seconds <= 1)
            {
                _timer?.Dispose();
                await InvokeAsync(() => Navigation.NavigateTo("/", true));
            }
            else
            {
                _seconds--;
                await InvokeAsync(StateHasChanged);
            }
        }, null, 1000, 1000);
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}