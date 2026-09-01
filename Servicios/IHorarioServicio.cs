
using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface IHorarioServicio
    {
        Task<HorarioDTO> AddAsync(HorarioCrearDTO dto, int idComplejo);
        Task<bool> DeleteAsync(int id,int dia);
        Task<HorarioDTO?> GetAsync(int id, int dia);
        Task<IEnumerable<HorarioDTO>> GetAllAsync(int id);
        Task<bool> UpdateAsync(HorarioEditarDTO dto,int idComplejo,int numDia);
    }
}
