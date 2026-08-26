using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ILocalidadRepositorio
    {
        Task<Localidad?> GetAsync(int id);
        Task<IEnumerable<Localidad>> GetAllAsync();
    }
}
