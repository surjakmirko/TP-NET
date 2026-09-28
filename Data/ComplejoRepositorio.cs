using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;


namespace Data
{
    public class ComplejoRepositorio:IComplejoRepositorio
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

        public async Task<Complejo?> GetAsync(int id)
        {
            return await _context.Complejos
            .Include(c => c.Localidad)
            .Include(c => c.Dueño)
                .ThenInclude(d => d.PersonaJuridica)
            .Include(c => c.Encargado)
            .FirstOrDefaultAsync(c => c.Id == id); ;
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
            return await _context.Complejos.Where(c => c.DueñoId == idDueno).ToListAsync();
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
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                query = query.Where(c => c.Localidad != null && c.Localidad.Nombre.Contains(ciudad));
            }

            if (!string.IsNullOrWhiteSpace(deporte))
            {
                query = query.Where(c => c.Canchas.Any(can => can.TipoCancha != null && can.TipoCancha.Deporte.Contains(deporte)));
            }

            return await query.ToListAsync();
        }
    }
}
