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
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // 1. Verificar si el token expiró
                if (jwtToken.ValidTo < DateTime.UtcNow)
                {
                    await _authService.LogoutAsync(); // O remover token de localStorage
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                // 2. Especificar explícitamente el tipo de autenticación ("jwt") y las claims para Name y Role
                var identity = new ClaimsIdentity(
                    claims: jwtToken.Claims,
                    authenticationType: "jwt",
                    nameType: ClaimTypes.Name,
                    roleType: ClaimTypes.Role
                );

                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}