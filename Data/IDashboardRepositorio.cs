using Modelo.Dominio;

namespace Data
{
    public interface IDashboardRepositorio
    {
        Task<IEnumerable<Complejo>> ObtenerDatosDashboardDueno(int idDueno, DateOnly fecha);
    }
}
