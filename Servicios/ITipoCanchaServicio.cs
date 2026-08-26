using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface ITipoCanchaServicio
    {
        Task<TipoCanchaDTO> AddAsync(TipoCanchaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TipoCanchaDTO?> GetAsync(int id);
        Task<IEnumerable<TipoCanchaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(TipoCanchaDTO dto);
        //Task<IEnumerable<TipoCanchaDTO>> GetByCriteriaAsync(TipoCanchaCriteriaDTO criteriaDTO);
    }
}
