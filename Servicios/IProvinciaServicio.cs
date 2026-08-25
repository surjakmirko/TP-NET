using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface IProvinciaServicio
    {
        Task<ProvinciaDTO?> GetAsync(int id);
        Task<IEnumerable<ProvinciaDTO>> GetAllAsync();
    }
}
