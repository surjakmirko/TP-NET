using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PrecioRepositorio : IPrecioRepositorio
    {
        private readonly AplicacionDbContext _context;
        public PrecioRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Precio precio)
        {
            await _context.Precios.AddAsync(precio);
            await _context.SaveChangesAsync();
        }
       
        public async Task<Precio?> GetAsync(int complejoId, int nro, DateOnly fechaDesde)
        {
            return await _context.Precios.FindAsync(complejoId, nro, fechaDesde);
        }
        public async Task<IEnumerable<Precio>> GetAllAsync(int complejoId, int nro)
        {
            return await _context.Precios
                .Where(p => (p.ComplejoId == complejoId && p.CanchaNro == nro))
                .ToListAsync();
        }
        
        public async Task<bool> FechaDesdeExistsAsync(DateOnly fechaDesde)
        {
            return await _context.Precios
                .AnyAsync(p => p.FechaDesde == fechaDesde);
        }
    }
}
