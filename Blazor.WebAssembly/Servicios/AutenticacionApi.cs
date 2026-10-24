using System.Threading.Tasks;
using DTOs;
using Blazor.WebAssembly.Servicios;

namespace Blazor.WebAssembly.Servicios
{
    public class AutenticacionApi : BlazorApiClient
    {
        public AutenticacionApi(HttpClient http) : base(http) { }

        public async Task<LoginResponseDTO?> LoginAsync(LoginDTO request)
        {
            return await PostAsync<LoginDTO, LoginResponseDTO>("auth/login", request);
        }
    }
}