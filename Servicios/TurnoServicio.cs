
using Modelo.Dominio;
using Data;
using DTOs;


namespace Servicios
{
    public class TurnoServicio: ITurnoServicio
    {
        private readonly ITurnoRepositorio turnoRepositorio;

        public TurnoServicio(ITurnoRepositorio turnoRepositorio)
        {
            this.turnoRepositorio = turnoRepositorio;
        }
        public async Task<TurnoDTO> AddAsync(TurnoDTO dto)
        {

            Turno turno = new Turno(dto.Id, dto.HoraInicio, dto.HoraFin,dto.ClienteId,dto.TipoTurnoId,dto.ComplejoId,dto.CanchaNro,dto.Fecha);

            dto.Id = turno.Id;

            await turnoRepositorio.AddAsync(turno);

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await turnoRepositorio.DeleteAsync(id);
        }

        public async Task<TurnoDTO?> GetAsync(int id)
        {
            Turno? turno = await turnoRepositorio.GetAsync(id);

            if (turno == null)
                return null;

            return new TurnoDTO
            {
                Id=turno.Id,
                HoraInicio = turno.HoraInicio,
                HoraFin=turno.HoraFin,
                ClienteId=turno.ClienteId,
                TipoTurnoId=turno.TipoTurnoId,
                ComplejoId=turno.ComplejoId,
                CanchaNro=turno.CanchaNro,
                Fecha=turno.Fecha

            };
        }

        public async Task<IEnumerable<TurnoDTO>> GetAllAsync()
        {
            var turnos = await turnoRepositorio.GetAllAsync();

            return turnos.Select(turno => new TurnoDTO
            {
                Id = turno.Id,
                HoraInicio = turno.HoraInicio,
                HoraFin = turno.HoraFin,
                ClienteId = turno.ClienteId,
                TipoTurnoId = turno.TipoTurnoId,
                ComplejoId = turno.ComplejoId,
                CanchaNro = turno.CanchaNro,
                Fecha = turno.Fecha
            }).ToList();
        }

        public async Task<bool> UpdateAsync(TurnoDTO dto)
        {

            Turno turno = new Turno(dto.Id, dto.HoraInicio, dto.HoraFin, dto.ClienteId, dto.TipoTurnoId, dto.ComplejoId, dto.CanchaNro, dto.Fecha);
            dto.Id = turno.Id;

            return await turnoRepositorio.UpdateAsync(turno);
        }

    }
}
