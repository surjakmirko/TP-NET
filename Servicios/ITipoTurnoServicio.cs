using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface ITipoTurnoServicio
    {
        Task<TipoTurnoDTO?> GetAsync(int id);
        Task<IEnumerable<TipoTurnoDTO>> GetAllAsync();
    }
}
