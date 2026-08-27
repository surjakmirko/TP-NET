using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProvinciaRepositorio : IProvinciaRepositorio
    {
        private readonly AplicacionDbContext _context;
        public ProvinciaRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }
        public async Task<Provincia?> GetAsync(int id)
        {
            return await _context.Provincias.FindAsync(id);
        }
        public async Task<IEnumerable<Provincia>> GetAllAsync()
        {
            return await _context.Provincias.ToListAsync();
        }
    }
}
