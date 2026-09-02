using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CanchaRepositorio : ICanchaRepositorio
    {
        private readonly AplicacionDbContext _context;
        public CanchaRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cancha cancha)
        {
            _context.Canchas.Add(cancha);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int complejoId, int nro)
        {
            var cancha = await _context.Canchas.FindAsync(complejoId, nro);
            if (cancha == null)
            {
                return false;
            }
            _context.Canchas.Remove(cancha);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Cancha?> GetAsync(int complejoId, int nro)
        {
            return await _context.Canchas.FindAsync(complejoId, nro);
        }
        public async Task<IEnumerable<Cancha>> GetAllAsync(int id)
        {
            return await _context.Canchas
                .Where(c => c.ComplejoId == id) 
                .ToListAsync();
        }
        public async Task<bool> UpdateAsync(Cancha cancha, int nroOriginal)
        {
            // Buscamos la cancha existente por su clave primaria compuesta original (ComplejoId, nroOriginal)
            var existingCancha = await _context.Canchas.FindAsync(cancha.ComplejoId, nroOriginal);

            if (existingCancha == null)
            {
                return false;
            }

            // Si el número de cancha cambió, en EF Core con PK compuesta eliminamos el registro viejo y agregamos el nuevo
            if (nroOriginal != cancha.Nro)
            {
                _context.Canchas.Remove(existingCancha);
                await _context.Canchas.AddAsync(cancha);
            }
            else
            {
                // Si el número no cambió, solo actualizamos los demás atributos
                existingCancha.SetTipoCanchaId(cancha.TipoCanchaId);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
