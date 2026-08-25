using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Servicios
{
    public interface IPersonaJuridicaServicio
    {
        Task<PersonaJuridicaDTO> AddAsync(PersonaJuridicaDTO dto);
        Task<bool> DeleteAsync(string cuit);
        Task<PersonaJuridicaDTO?> GetAsync(string cuit);
        Task<IEnumerable<PersonaJuridicaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(PersonaJuridicaDTO dto);
    }
}
