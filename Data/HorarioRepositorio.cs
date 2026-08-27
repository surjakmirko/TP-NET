using Modelo.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HorarioRepositorio:IHorarioRepositorio
    {
        private readonly AplicacionDbContext _context;

        public HorarioRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Horario>> GetAllAsync(int id)
        {
            return await _context.Horarios
                .Where(h => h.ComplejoId == id)
                .ToListAsync();
        }

        public async Task<Horario?> GetAsync(int id, int nro)
        {
            return await _context.Horarios.FindAsync(id, nro);
        }
        public async Task AddAsync(Horario horario)
        {
            await _context.Horarios.AddAsync(horario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Horario horario)
        {
            Horario horarioBuscado = await _context.Horarios.FindAsync(horario.ComplejoId,horario.NroDia);
            if (horarioBuscado == null)
            {
                return false;
            }
            _context.Horarios.Update(horarioBuscado);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id, int nro)
        {
            var horarioBuscado = await _context.Horarios.FindAsync(id, nro);
            if (horarioBuscado == null) return false;

            _context.Horarios.Remove(horarioBuscado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
