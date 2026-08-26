using Data;
using DTOs;
using Modelo.Dominio;


namespace Servicios
{
    public class TipoTurnoServicio : ITipoTurnoServicio
    {
        private readonly ITipoTurnoRepositorio tipoTurnoRepositorio;

        public TipoTurnoServicio(ITipoTurnoRepositorio tipoTurnoRepositorio)
        {
            this.tipoTurnoRepositorio = tipoTurnoRepositorio;
        }
        public async Task<TipoTurnoDTO?> GetAsync(int id)
        {
            TipoTurno? tipoTurno = await tipoTurnoRepositorio.GetAsync(id);

            if (tipoTurno == null)
                return null;

            return new TipoTurnoDTO
            {
                Id = tipoTurno.Id,
                Nombre = tipoTurno.Nombre,
                Descripcion = tipoTurno.Descripcion
            };
        }

        public async Task<IEnumerable<TipoTurnoDTO>> GetAllAsync()
        {
            var tiposTurno = await tipoTurnoRepositorio.GetAllAsync();

            return tiposTurno.Select(tipoTurno => new TipoTurnoDTO
            {
                Id = tipoTurno.Id,
                Nombre = tipoTurno.Nombre,
                Descripcion = tipoTurno.Descripcion
            }).ToList();
        }
    }
}
