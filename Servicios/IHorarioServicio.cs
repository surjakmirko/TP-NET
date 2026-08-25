
using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface IHorarioServicio
    {
        Task<HorarioDTO> AddAsync(HorarioDTO dto);
        Task<bool> DeleteAsync(int id,int dia);
        Task<HorarioDTO?> GetAsync(int id, int dia);
        Task<IEnumerable<HorarioDTO>> GetAllAsync(int id);
        Task<bool> UpdateAsync(HorarioDTO dto);
    }
}
