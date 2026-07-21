using Modelo.Dominio;

namespace Data
{
    public interface ITipoUsuarioRepositorio
    {
        Task AddAsync(TipoUsuario tipousuario);
        Task<bool> DeleteAsync(int id);
        Task<TipoUsuario?> GetAsync(int id);
        Task<IEnumerable<TipoUsuario>> GetAllAsync();
        Task<bool> UpdateAsync(TipoUsuario tipousuario);
    }
}
