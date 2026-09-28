using DTOs;
namespace API
{
    public class CanchaApiClient: BaseApiClient
    {
        public static async Task<List<CanchaDTO>?> ObtenerPorComplejoIdAsync(int idComplejo)
        {
            return await GetAsync<List<CanchaDTO>>($"complejos/{idComplejo}/canchas");
        }
    }
}
