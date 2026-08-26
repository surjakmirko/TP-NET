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

        Task<TipoCanchaDTO?> GetAsync(int id);
        Task<IEnumerable<TipoCanchaDTO>> GetAllAsync();
        //Task<IEnumerable<TipoCanchaDTO>> GetByCriteriaAsync(TipoCanchaCriteriaDTO criteriaDTO);
    }
}
