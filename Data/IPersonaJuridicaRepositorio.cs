using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPersonaJuridicaRepositorio
    {
        Task AddAsync(PersonaJuridica personajuridica);
        Task<bool> DeleteAsync(string cuit);
        Task<PersonaJuridica?> GetAsync(string cuit);
        Task<IEnumerable<PersonaJuridica>> GetAllAsync();
        Task<bool> UpdateAsync(PersonaJuridica personajuridica);
        Task<bool> CuitExistsAsync(string cuit);
    }
}
