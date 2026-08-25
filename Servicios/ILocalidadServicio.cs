using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface ILocalidadServicio
    {
        Task<LocalidadDTO?> GetAsync(int id);
        Task<IEnumerable<LocalidadDTO>> GetAllAsync();
    }
}
