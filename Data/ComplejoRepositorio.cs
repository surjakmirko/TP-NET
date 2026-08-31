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
            return await _context.Complejos.ToListAsync();
        }

        public async Task<Complejo?> GetAsync(int id)
        {
            return await _context.Complejos.FindAsync(id);
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
            _context.Complejos.Update(complejoBuscado);
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
    }
}
