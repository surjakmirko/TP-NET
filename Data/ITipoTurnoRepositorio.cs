

using Modelo.Dominio;

namespace Data
{
    public interface ITipoTurnoRepositorio
    {
        Task<TipoTurno?> GetAsync(int id);
        Task<IEnumerable<TipoTurno>> GetAllAsync();
    }
}
