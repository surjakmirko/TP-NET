using System.Threading.Tasks;
using DTOs; 

namespace API
{
    public class LocalidadApiClient : BaseApiClient
    {
        public static async Task<LocalidadDTO?> ObtenerPorIdAsync(int id)
        {
            return await GetAsync<LocalidadDTO>($"localidades/{id}");
        }
    }
}