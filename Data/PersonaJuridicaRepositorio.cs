using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;

namespace Data
{
    public class PersonaJuridicaRepositorio : IPersonaJuridicaRepositorio
        {
            private readonly AplicacionDbContext _context;

            public PersonaJuridicaRepositorio(AplicacionDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<PersonaJuridica>> GetAllAsync()
            {
                return await _context.PersonaJuridicas.ToListAsync();
            }
        public async Task<PersonaJuridica?> GetAsync(string cuit)
            {
                return await _context.PersonaJuridicas.FindAsync(cuit);
            }

            public async Task AddAsync(PersonaJuridica personaJuridica)
            {
                await _context.PersonaJuridicas.AddAsync(personaJuridica);
                await _context.SaveChangesAsync();
            }

            public async Task<bool> UpdateAsync(PersonaJuridica personaJuridica)
            {
                PersonaJuridica persona = await _context.PersonaJuridicas.FindAsync(personaJuridica.Cuit);
                if (persona == null)
                {
                    return false;
                }
                _context.PersonaJuridicas.Update(persona);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteAsync(string cuit)
            {
                PersonaJuridica persona = await _context.PersonaJuridicas.FindAsync(cuit);
                if (persona == null)
                {
                    return false;
                }
                _context.PersonaJuridicas.Remove(persona);
                await _context.SaveChangesAsync();
                return true;

            }

            public async Task<bool> SaveChangesAsync()
            {
                return await _context.SaveChangesAsync() > 0;
            }

            public async Task<bool> CuitExistsAsync(string cuit)
            {
                bool existe = await _context.PersonaJuridicas.AnyAsync(p => p.Cuit == cuit);
                return existe;
            }
        }
    }

