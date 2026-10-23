using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;

namespace Data
{
    public class DashboardRepositorio : IDashboardRepositorio
    {
        private readonly AplicacionDbContext _context;

        public DashboardRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Complejo>> ObtenerDatosDashboardDueno(int idDueno, DateOnly fecha)
        {
            return await _context.Complejos
                .AsNoTracking()
                .AsSplitQuery()
                .Where(c => c.DueñoId == idDueno)
                .Include(c => c.Horarios)
                .Include(c => c.Canchas)
                    .ThenInclude(ca => ca.TipoCancha)
                .Include(c => c.Canchas)
                    .ThenInclude(ca => ca.Precios)
                .Include(c => c.Canchas)
                    .ThenInclude(ca => ca.Turnos.Where(t => t.Fecha == fecha))
                .ToListAsync();
        }
    }
}
