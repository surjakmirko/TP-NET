using DTOs;
using System.Diagnostics.CodeAnalysis;


namespace API
{
    public class PersonaFisicaApiClient : BaseApiClient
    {
        public static async Task CrearPersonaFisicaAsync(PersonaFisicaDTO dto)
        {
            await PostAsync("personasfisicas", dto);
        }

        public static async Task<PersonaFisicaDTO> ObtenerPersonaPorDniAsync(string dni)
        {
            return await GetAsync<PersonaFisicaDTO>($"personafisicas/{dni}");
        }
    }
}

