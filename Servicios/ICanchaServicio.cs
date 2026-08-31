using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface ICanchaServicio
    {
        Task<CanchaDTO> AddAsync(CanchaCrearDTO dto, int complejoId);
        Task<bool> DeleteAsync(int id, int nro);
        Task<CanchaDTO?> GetAsync(int id, int nro);
        Task<IEnumerable<CanchaDTO>> GetAllAsync(int id);
        Task<bool> UpdateAsync(CanchaCrearDTO dto, int complejoId, int nro);
    }
}
