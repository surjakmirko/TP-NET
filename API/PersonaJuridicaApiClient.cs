using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class PersonaJuridicaApiClient : BaseApiClient
    {
        public static async Task CrearPersonaJuridicaAsync(PersonaJuridicaDTO dto)
        {
            // Apunta al endpoint correspondiente en la WebAPI
            await PostAsync("api/personajuridica", dto);
        }
    }
}