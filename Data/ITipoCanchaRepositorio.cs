

using Modelo.Dominio;

namespace Data
{
    public interface ITipoCanchaRepositorio
    {
        Task<TipoCancha?> GetAsync(int id);
        Task<IEnumerable<TipoCancha>> GetAllAsync();
    }
}
