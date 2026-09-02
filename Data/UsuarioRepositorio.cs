
using Modelo.Dominio;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;


namespace Data
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AplicacionDbContext _context;

        public UsuarioRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .Include(u => u.PersonaFisica)
                .Include(u => u.PersonaJuridica)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .Include(u => u.PersonaFisica)
                .Include(u => u.PersonaJuridica)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .Include(u => u.PersonaFisica)
                .Include(u => u.PersonaJuridica)
                .ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(usuario.Id);
            if (existingUsuario == null)
            {
                return false;
            }
            existingUsuario.SetEmail(usuario.Email);
            existingUsuario.SetTelefono(usuario.Telefono);
            existingUsuario.SetPassword(usuario.Password);
            existingUsuario.SetTipoUsuarioId(usuario.TipoUsuarioId);
            existingUsuario.SetPersonaFisicaDni(usuario.PersonaFisicaDni);
            existingUsuario.SetPersonaJuridicaCuit(usuario.PersonaJuridicaCuit);

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }
        public async Task<int> IniciarSesion(string email, string password)
        {
            //PREVIO A HASH DE CONTRASEÑA
            //Usuario? usuario = await _context.Usuarios
            //    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Password == password);
            //return usuario?.Id ?? 0;

            Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (usuario == null)
            {
                return 0;
            }
            bool validacion = BCrypt.Net.BCrypt.Verify(password, usuario.Password);

            return validacion ? usuario.Id : 0;

        }
    }
}