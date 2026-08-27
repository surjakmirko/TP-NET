using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;

namespace Data
{
    public class TipoCanchaRepositorio : ITipoCanchaRepositorio
    {
        private readonly AplicacionDbContext _context;
        public TipoCanchaRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }   
        public async Task<TipoCancha?> GetAsync(int id)
        {
            return await _context.TipoCanchas.FindAsync(id);
        }
        public async Task<IEnumerable<TipoCancha>> GetAllAsync()
        {
            return await _context.TipoCanchas.ToListAsync();
        }
    }
}
