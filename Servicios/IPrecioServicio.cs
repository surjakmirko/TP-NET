using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IPrecioServicio
    {
        Task<PrecioDTO> AddAsync(PrecioDTO dto);
        Task<bool> DeleteAsync(int id,int nro,DateOnly FechaDesde);
        Task<PrecioDTO?> GetAsync(int id, int nro,DateOnly FechaDesde);
        Task<IEnumerable<PrecioDTO>> GetAllAsync(int id, int nro);
        Task<bool> UpdateAsync(PrecioDTO dto);
    }
}
