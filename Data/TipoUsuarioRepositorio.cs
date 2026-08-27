using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;

namespace Data
{
    public class TipoUsuarioRepositorio : ITipoUsuarioRepositorio
    {
        private readonly AplicacionDbContext _context;

        public TipoUsuarioRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }



        public async Task<TipoUsuario?> GetAsync(int id)
        {
            return await _context.TipoUsuarios.FindAsync(id);
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllAsync()
        {
            return await _context.TipoUsuarios.ToListAsync();
        }
        


    }

}
