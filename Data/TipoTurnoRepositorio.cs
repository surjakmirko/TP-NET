using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoTurnoRepositorio : ITipoTurnoRepositorio
    {
        private readonly AplicacionDbContext _context;
        public TipoTurnoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }
        public async Task<TipoTurno?> GetAsync(int id)
        {
            return await _context.TipoTurnos.FindAsync(id);
        }
        public async Task<IEnumerable<TipoTurno>> GetAllAsync()
        {
            return await _context.TipoTurnos.ToListAsync();
        }
    }
}
