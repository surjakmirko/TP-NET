using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IComplejoRepositorio
    {
        Task AddAsync(Complejo complejo);
        Task<bool> DeleteAsync(int id);
        Task<Complejo?> GetAsync(int id);
        Task<IEnumerable<Complejo>> GetAllAsync();
        Task<bool> UpdateAsync(Complejo complejo);
        Task<IEnumerable<Complejo>> GetComplejosByIdDueno(int idDueno);
        Task<IEnumerable<Complejo>> BuscarAsync(string? ciudad, string? deporte, string? fecha, string? hora, decimal? min, decimal? max);

    }
}
