using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IComplejoServicio
    {
        Task<ComplejoDTO> AddAsync(ComplejoCrearDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<ComplejoDTO?> GetAsync(int id);
        Task<IEnumerable<ComplejoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ComplejoDTO dto);

        Task<IEnumerable<ComplejoDTO>> GetByDuenoAsync(int idDueno);

        Task<IEnumerable<ComplejoDTO>> BuscarAsync(string? ciudad, string? deporte, string? fecha, string? hora, decimal? min, decimal? max);
    }
}
