using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICanchaRepositorio
    {
        Task AddAsync(Cancha cancha);
        Task<bool> DeleteAsync(int id,int nro);
        Task<Cancha?> GetAsync(int id,int nro);
        Task<IEnumerable<Cancha>> GetAllAsync(int id);
        Task<bool> UpdateAsync(Cancha cancha);
    }
}
