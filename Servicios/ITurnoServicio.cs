using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface ITurnoServicio
    {
        Task<TurnoDTO> AddAsync(TurnoCrearDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TurnoDTO?> GetAsync(int id);
        Task<IEnumerable<TurnoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(TurnoDTO dto);
    }
}
        