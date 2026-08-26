using Modelo.Dominio;

namespace Data
{
    public interface IHorarioRepositorio
    {
        Task AddAsync(Horario horario);
        Task<bool> DeleteAsync(int id, int nro);
        Task<Horario?> GetAsync(int id, int nro);
        Task<IEnumerable<Horario>> GetAllAsync(int id);
        Task<bool> UpdateAsync(Horario horario);
    }
}
