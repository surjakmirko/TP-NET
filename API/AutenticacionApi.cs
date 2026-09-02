using DTOs;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace API
{
    public class AutenticacionApi: BaseApiClient
    {
        public static async Task<LoginResponseDTO?> LoginAsync(LoginDTO request)
        {
            using var httpClient = await CreateHttpClientAsync();

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponseDTO>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return null;
        }
    }
}
