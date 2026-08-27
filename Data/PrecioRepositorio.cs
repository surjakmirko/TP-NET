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
        public async Task<bool> DeleteAsync(int id, int nro, DateOnly fechaDesde)
        {
            var precioBuscado = await _context.Precios.FindAsync(id, nro, fechaDesde);
            if (precioBuscado == null) return false;

            _context.Precios.Remove(precioBuscado);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Precio?> GetAsync(int id, int nro, DateOnly fechaDesde)
        {
            return await _context.Precios.FindAsync(id, nro, fechaDesde);
        }
        public async Task<IEnumerable<Precio>> GetAllAsync(int id, int nro)
        {
            return await _context.Precios
                .Where(p => (p.ComplejoId == id && p.CanchaNro == nro))
                .ToListAsync();
        }
        public async Task<bool> UpdateAsync(Precio precio)
        {
            Precio precioBuscado = await _context.Precios.FindAsync(precio.ComplejoId, precio.CanchaNro, precio.FechaDesde);
            if (precioBuscado == null)
            {
                return false;
            }
            _context.Precios.Update(precioBuscado);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> FechaDesdeExistsAsync(DateOnly fechaDesde)
        {
            return await _context.Precios
                .AnyAsync(p => p.FechaDesde == fechaDesde);
        }
    }
}
