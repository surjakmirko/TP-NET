using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class PersonaJuridicaApiClient : BaseApiClient
    {
        public static async Task CrearPersonaJuridicaAsync(PersonaJuridicaDTO dto)
        {
            await PostAsync("personajuridica", dto);
        }
    }
}