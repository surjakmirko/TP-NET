using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LocalidadRepositorio : ILocalidadRepositorio
    {
        private readonly AplicacionDbContext _context;
        public LocalidadRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }
        public async Task<Localidad?> GetAsync(int id)
        {
            return await _context.Localidades.FindAsync(id);
        }
        public async Task<IEnumerable<Localidad>> GetAllAsync()
        {
            return await _context.Localidades.ToListAsync();
        }
    }
}
