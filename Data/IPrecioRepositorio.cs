using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPrecioRepositorio
    {
        Task AddAsync(Precio precio);
       
        Task<Precio?> GetAsync(int comjplejoId, int nro, DateOnly fechaDesde);
        Task<IEnumerable<Precio>> GetAllAsync(int id, int nro);
       
        Task<bool> FechaDesdeExistsAsync(DateOnly fechaDesde);
    }
}
