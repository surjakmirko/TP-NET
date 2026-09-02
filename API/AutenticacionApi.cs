using DTOs;
using System.Net.Http.Json;


namespace API
{
    public class AutenticacionApi: BaseApiClient
    {
        public async Task<UsuarioDTO?> LoginAsync(LoginDTO loginDto)
        {
            using var client = await CreateHttpClientAsync();

            // Petición POST al endpoint de login
            var response = await client.PostAsJsonAsync("login", loginDto);

            if (!response.IsSuccessStatusCode)
            {
                return null; // Credenciales inválidas o error de usuario no encontrado
            }

            // Retorna los datos del usuario logueado en caso de éxito
            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }
    }
}
