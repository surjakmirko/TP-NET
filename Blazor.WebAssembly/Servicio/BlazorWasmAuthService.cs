using API;
using API.Client;
using DTOs;
using Microsoft.JSInterop;
namespace Blazor.WebAssembly.Servicios
{
    public class BlazorWasmAuthService : IAutenticacionService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly AutenticacionApi _authClient; // Inyectamos el ApiClient

        private const string TOKEN_KEY = "auth_token";
        private const string USERNAME_KEY = "auth_username";
        private const string EXPIRATION_KEY = "auth_expiration";

        public event Action<bool>? AuthenticationStateChanged;

        public BlazorWasmAuthService(IJSRuntime jsRuntime, AutenticacionApi authClient)
        {
            _jsRuntime = jsRuntime;
            _authClient = authClient;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            var expiration = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", EXPIRATION_KEY);

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(expiration))
            {
                if (DateTime.TryParse(expiration, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime exp))
                {
                    return DateTime.UtcNow < exp;
                }
            }
            return false;
        }

        public async Task<string?> GetTokenAsync()
        {
            try
            {
                return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TOKEN_KEY);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var request = new LoginDTO { Email = email, Password = password };
                var response = await AutenticacionApi.LoginAsync(request);

                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TOKEN_KEY, response.Token);

                    AuthenticationStateChanged?.Invoke(true);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TOKEN_KEY);
            
            AuthenticationStateChanged?.Invoke(false);
        }
    }
}