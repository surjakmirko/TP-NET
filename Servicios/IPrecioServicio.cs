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
        Task<PrecioDTO> AddAsync(PrecioCrearDTO dto, int complejoId, int nroCancha);
        Task<PrecioDTO?> GetAsync(int compleojoId,int nro,DateOnly FechaDesde);
        Task<IEnumerable<PrecioDTO>> GetAllAsync(int complejopId,int nro);
    }
}
