
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;
using System.Net;

namespace Data
{
    public class PersonaFisicaRepositorio: IPersonaFisicaRepositorio
    {
        private readonly AplicacionDbContext _context;

        public PersonaFisicaRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonaFisica>> GetAllAsync()
        {
            return await _context.PersonaFisicas.ToListAsync();
        }

        public async Task<PersonaFisica?> GetAsync(string dni)
        {
            return await _context.PersonaFisicas.FindAsync(dni);
        }

        public async Task AddAsync(PersonaFisica personaFisica)
        {
            await _context.PersonaFisicas.AddAsync(personaFisica);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(PersonaFisica personaFisica)
        {
            PersonaFisica persona = await _context.PersonaFisicas.FindAsync(personaFisica.Dni);
            if (persona == null)
            {
                return false;
            }
            _context.PersonaFisicas.Update(persona);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string dni)
        {
            PersonaFisica persona = await _context.PersonaFisicas.FindAsync(dni);
            if (persona == null)
            {
                return false;
            }
            _context.PersonaFisicas.Remove(persona);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DniExistsAsync(string dni)
        {
            bool existe = await _context.PersonaFisicas.AnyAsync(p => p.Dni == dni);
            return existe;
        }
    }
}