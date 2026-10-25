using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;


namespace Data
{
    public class ComplejoRepositorio : IComplejoRepositorio
    {
        private readonly AplicacionDbContext _context;

        public ComplejoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Complejo>> GetAllAsync()
        {
            return await _context.Complejos
                .Include(c => c.Localidad)
                .Include(c => c.Dueño)
                    .ThenInclude(d => d.PersonaJuridica)
                .Include(c => c.Encargado)
                .ToListAsync();
        }
        public async Task<IEnumerable<(string Localidad, int Cantidad)>> GetRankingLocalidadesAsync()
        {
            var localidades = await _context.Complejos
                .Include(c => c.Localidad)
                .GroupBy(c => c.Localidad.Nombre)
                .Select(g => new
                {
                    Localidad = g.Key,
                    Cantidad = g.Count()
                })
                .OrderByDescending(x => x.Cantidad)
                .ToListAsync();

            return localidades.Select(x => (x.Localidad, x.Cantidad)).ToList();
        }
        public async Task<Complejo?> GetAsync(int id)
        {
            return await _context.Complejos
            .Include(c => c.Localidad)
              .Include(c => c.Horarios)                     // Include para Horarios
                .Include(c => c.Canchas)                      // Include para Canchas
                    .ThenInclude(ca => ca.TipoCancha)        // Relación con TipoCancha
        .Include(c => c.Canchas)
            .ThenInclude(ca => ca.Precios)           // Relación con Precios
        .Include(c => c.Canchas)
            .ThenInclude(ca => ca.Turnos)
        .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task AddAsync(Complejo complejo)
        {
            await _context.Complejos.AddAsync(complejo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Complejo complejo)
        {
            Complejo complejoBuscado = await _context.Complejos.FindAsync(complejo.Id);
            if (complejoBuscado == null)
            {
                return false;
            }
            complejoBuscado.SetDireccion(complejo.Direccion);
            complejoBuscado.SetNombre(complejo.Nombre);
            complejoBuscado.SetDueñoId(complejo.DueñoId);
            complejoBuscado.SetEncargadoId(complejo.EncargadoId);
            complejoBuscado.SetLocalidadId(complejo.LocalidadId);
            complejoBuscado.SetImagenUrl(complejo.ImagenUrl);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Complejo complejo = await _context.Complejos.FindAsync(id);
            if (complejo == null)
            {
                return false;
            }
            _context.Complejos.Remove(complejo);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Complejo>> GetComplejosByIdDueno(int idDueno)
        {
            return await _context.Complejos
                .Include(c => c.Localidad)
                .Include(c => c.Canchas)
                    .ThenInclude(ca => ca.TipoCancha) 
                .Where(c => c.DueñoId == idDueno)
                .ToListAsync();
        }

        public async Task<Complejo?> GetComplejosByIdEncargado(int idEncargado)
        {
            return await _context.Complejos
                .Include(c => c.Horarios)
                .Include(c => c.Localidad)
                .Include(c => c.Canchas)
                    .ThenInclude(can => can.Turnos)
                .Include(c => c.Canchas)
                    .ThenInclude(can => can.TipoCancha)
                 .FirstOrDefaultAsync(c => c.EncargadoId == idEncargado);
        }


        public async Task<IEnumerable<Complejo>> BuscarAsync(string? ciudad, string? deporte, string? fecha, string? hora, decimal? min, decimal? max)
        {
            var query = _context.Complejos
                .Include(c => c.Localidad)
                .Include(c => c.Dueño)
                    .ThenInclude(d => d.PersonaJuridica)
                .Include(c => c.Encargado)
                .Include(c => c.Canchas)
                    .ThenInclude(can => can.TipoCancha)
                .Include(c => c.Canchas)
                    .ThenInclude(can => can.Precios)
                .Include(c => c.Horarios)
                .AsQueryable();

            // 1. Filtro por ciudad (localidad)
            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                query = query.Where(c => c.Localidad != null && c.Localidad.Nombre.Contains(ciudad));
            }

            // 2. Filtro por deporte (TipoCanchaId) - el frontend envía el ID como string
            if (!string.IsNullOrWhiteSpace(deporte) && int.TryParse(deporte, out int deporteId))
            {
                query = query.Where(c => c.Canchas.Any(can => can.TipoCanchaId == deporteId));
            }

            // 3. Filtro por fecha y hora - verificar que el complejo tenga horario ese día y hora
            if (!string.IsNullOrWhiteSpace(fecha) && DateOnly.TryParse(fecha, out DateOnly fechaParsed))
            {
                int nroDia = (fechaParsed.DayOfWeek == DayOfWeek.Sunday) ? 7 : (int)fechaParsed.DayOfWeek;

                query = query.Where(c => c.Horarios.Any(h => h.NroDia == nroDia));

                if (!string.IsNullOrWhiteSpace(hora) && TimeOnly.TryParse(hora, out TimeOnly horaParsed))
                {
                    query = query.Where(c => c.Horarios.Any(h => h.NroDia == nroDia && h.HoraApertura <= horaParsed && h.HoraCierre > horaParsed));
                }
            }

            // 4. Filtro por precio (min/max) - verificar que al menos una cancha tenga precio en el rango
            if (min.HasValue || max.HasValue)
            {
                query = query.Where(c => c.Canchas.Any(can => can.Precios.Any(p =>
                    (!min.HasValue || p.PrecioBase >= min.Value) &&
                    (!max.HasValue || p.PrecioBase <= max.Value)
                )));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> EncargadoTieneComplejoAsync(int encargadoId)
        {
            return await _context.Complejos.AnyAsync(c => c.EncargadoId == encargadoId);
        }
    }
}
