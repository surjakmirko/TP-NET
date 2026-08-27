using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TurnoRepositorio : ITurnoRepositorio
    {
        private readonly AplicacionDbContext _context;
        public TurnoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await _context.Turnos.ToListAsync();
        }
        public async Task<Turno?> GetAsync(int id)
        {
            return await _context.Turnos.FindAsync(id);
        }
        public async Task AddAsync(Turno turno)
        {
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Turno turno)
        {
            var existingTurno = await _context.Turnos.FindAsync(turno.Id);
            if (existingTurno == null)
            {
                return false;
            }
            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return false;
            }
            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
