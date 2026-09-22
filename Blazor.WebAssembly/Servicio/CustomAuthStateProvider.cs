using API.Client;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blazor.WebAssembly.Servicios
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAutenticacionService _authService;

        public CustomAuthStateProvider(IAutenticacionService authService)
        {
            _authService = authService;

            // Si tu servicio notifica cuando cambia el estado, te suscribís acá
            if (_authService is BlazorWasmAuthService wasmAuth)
            {
                wasmAuth.AuthenticationStateChanged += (isAuthenticated) =>
                {
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                };
            }
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _authService.GetTokenAsync();

            if (string.IsNullOrWhiteSpace(token))
            {
                // Usuario Anónimo / No logueado
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            try
            {
                // Parseamos el JWT para extraer las Claims
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");

                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                // Si el token es inválido o no se puede leer
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}