using DTOs;

namespace API
{
    public class DashboardApiClient : BaseApiClient
    {
        public static async Task<DashboardDuenoDTO?> ObtenerMetricasDuenoAsync(int idDueno)
        {
            return await GetAsync<DashboardDuenoDTO>($"complejos/dueno/{idDueno}/dashboard");
        }
    }
}
