using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface ITipoUsuarioServicio
    {
        Task<TipoUsuarioDTO> AddAsync(TipoUsuarioDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TipoUsuarioDTO?> GetAsync(int id);
        Task<IEnumerable<TipoUsuarioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(TipoUsuarioDTO dto);
        //Task<IEnumerable<TipoUsuarioDTO>> GetByCriteriaAsync(TipoUsuarioCriteriaDTO criteriaDTO);
    }
}