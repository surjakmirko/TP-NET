using Modelo.Dominio;

namespace Data
{
    public interface ITipoUsuarioRepositorio
    {
        Task<TipoUsuario?> GetAsync(int id);
        Task<IEnumerable<TipoUsuario>> GetAllAsync();
        
    }
}
