using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDTO> AddAsync(UsuarioCrearDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioDTO?> GetAsync(int id);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(UsuarioDTO dto);
        Task<List<UsuarioDTO>> GetDuenosAsync();
    }
}