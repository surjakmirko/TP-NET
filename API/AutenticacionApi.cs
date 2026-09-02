using DTOs;
using System.Net.Http.Json;

namespace API
{
    public class AutenticacionApi : BaseApiClient
    {
        public static async Task<LoginResponseDTO?> LoginAsync(LoginDTO request)
        {
            using var httpClient = await CreateHttpClientAsync();

            var response = await httpClient.PostAsJsonAsync("/auth/login", request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
            }

            return null;
        }
    }
}