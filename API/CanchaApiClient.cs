using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class CanchaApiClient : BaseApiClient
    {
        public static async Task CrearCanchaAsync(CanchaCrearDTO dto)
        {
            await PostAsync("canchas", dto);
        }
        public static async Task<CanchaDTO?> ObtenerCanchaAsync(int idComplejo, int nroCancha)
        {
            return await GetAsync<CanchaDTO>($"canchas/{idComplejo}/{nroCancha}");
        }
        public static async Task ActualizarCanchaAsync(CanchaDTO dto)
        {
            await PutAsync("canchas", dto);
        }
        public static async Task<List<CanchaDTO>?> ObtenerPorComplejoAsync(int idComplejo)
        {
            return await GetAsync<List<CanchaDTO>>($"canchas/complejo/{idComplejo}");
        }
        public static async Task EliminarCanchaAsync(int idComplejo, int nroCancha)
        {
            await DeleteAsync($"canchas/{idComplejo}/{nroCancha}");
        }
    }
}
