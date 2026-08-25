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
        Task<bool> DeleteAsync(DateOnly FechaDesde);
        Task<PrecioDTO?> GetAsync(DateOnly FechaDesde);
        Task<IEnumerable<PrecioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(PrecioDTO dto);
    }
}
