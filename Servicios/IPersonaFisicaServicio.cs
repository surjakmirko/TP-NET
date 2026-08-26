using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IPersonaFisicaServicio
    {
        Task<PersonaFisicaDTO> AddAsync(PersonaFisicaDTO dto);
        Task<bool> DeleteAsync(int dni);
        Task<PersonaFisicaDTO?> GetAsync(int dni);
        Task<IEnumerable<PersonaFisicaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(PersonaFisicaDTO dto);
    }
}
