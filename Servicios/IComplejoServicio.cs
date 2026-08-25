using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface IComplejoServicio
    {
        Task<ComplejoDTO> AddAsync(ComplejoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<ComplejoDTO?> GetAsync(int id);
        Task<IEnumerable<ComplejoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ComplejoDTO dto);

    }
}
