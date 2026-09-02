using System.Threading.Tasks;
using DTOs; // Asumiendo que tenés un LocalidadDTO

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