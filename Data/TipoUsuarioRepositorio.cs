using Modelo.Dominio;

namespace Data
{
    public class TipoUsuarioRepositorio : ITipoUsuarioRepositorio
    {
        private static readonly List<TipoUsuario> tiposUsuarios = new List<TipoUsuario>();

        public Task AddAsync(TipoUsuario tipousuario)
        {
            tiposUsuarios.Add(tipousuario);
            return Task.CompletedTask;
        }

        public Task<TipoUsuario?> GetAsync(int id)
        {
            var tipousuario = tiposUsuarios.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(tipousuario);
        }

        public Task<IEnumerable<TipoUsuario>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<TipoUsuario>>(tiposUsuarios);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var tipo = tiposUsuarios.FirstOrDefault(c => c.Id == id);
            if (tipo != null)
            {
                tiposUsuarios.Remove(tipo);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<bool> UpdateAsync(TipoUsuario tipo)
        {
            var existe = tiposUsuarios.FirstOrDefault(t => t.Id == tipo.Id);
            if (existe != null)
            {
                existe.SetDescripcion(tipo.Descripcion);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }

}
