using DTOs;

namespace Servicios
{
    public interface IDashboardServicio
    {
        Task<DashboardDuenoDTO> ObtenerMetricasDuenoAsync(int idDueno, DateOnly fecha);
    }
}
