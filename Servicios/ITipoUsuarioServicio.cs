using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface ITipoUsuarioServicio
    {

        Task<TipoUsuarioDTO?> GetAsync(int id);
        Task<IEnumerable<TipoUsuarioDTO>> GetAllAsync();
  
    }
}