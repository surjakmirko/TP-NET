using Modelo.Dominio;

namespace Data
{
    public interface ITurnoRepositorio
    {
        Task AddAsync(Turno turno);
        Task<bool> DeleteAsync(int id);
        Task<Turno?> GetAsync(int id);
        Task<IEnumerable<Turno>> GetAllAsync();
        Task<bool> UpdateAsync(Turno turno);
    }
}
