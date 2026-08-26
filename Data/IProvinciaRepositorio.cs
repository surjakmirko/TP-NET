using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IProvinciaRepositorio
    {
        Task<Provincia?> GetAsync(int id);
        Task<IEnumerable<Provincia>> GetAllAsync();
    }
}
