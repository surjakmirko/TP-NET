
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
        public async Task<TurnoDTO> AddAsync(TurnoCrearDTO dto)
        {

            Turno turno = new Turno(dto.HoraInicio, dto.HoraFin,dto.ClienteId,dto.TipoTurnoId,dto.ComplejoId,dto.CanchaNro,dto.Fecha);


            await turnoRepositorio.AddAsync(turno);

            return new TurnoDTO
            {
                Id = turno.Id,
                HoraInicio = turno.HoraInicio,
                HoraFin = turno.HoraFin,
                ClienteId = turno.ClienteId,
                TipoTurnoId = turno.TipoTurnoId,
                ComplejoId = turno.ComplejoId,
                CanchaNro = turno.CanchaNro,
                Fecha = turno.Fecha,
                Estado = turno.Estado,
                MotivoCancelacion = turno.MotivoCancelacion
            };
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
                Fecha=turno.Fecha,
                Estado = turno.Estado,
                MotivoCancelacion = turno.MotivoCancelacion

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
                Fecha = turno.Fecha,
                Estado = turno.Estado,
                MotivoCancelacion = turno.MotivoCancelacion
            }).ToList();
        }

        public async Task<bool> UpdateAsync(TurnoDTO dto)
        {

            Turno turno = new Turno(dto.Id, dto.HoraInicio, dto.HoraFin, dto.ClienteId, dto.TipoTurnoId, dto.ComplejoId, dto.CanchaNro, dto.Fecha);
            dto.Id = turno.Id;

            return await turnoRepositorio.UpdateAsync(turno);
        }
        public async Task<List<TurnoDTO>> ObtenerPorClienteIdAsync(int idCliente)
        {
            var turnos = await turnoRepositorio.ObtenerPorClienteIdAsync(idCliente);

            return turnos.Select(t => new TurnoDTO
            {
                Id = t.Id,
                Fecha = t.Fecha,
                HoraInicio = t.HoraInicio,
                HoraFin = t.HoraFin,
                Estado = t.Estado,
                CanchaNro = t.CanchaNro,
                ComplejoId = t.ComplejoId,
                Complejo = t.Complejo != null ? new ComplejoDTO
                {
                    Id = t.Complejo.Id,
                    Nombre = t.Complejo.Nombre
                } : null,

                
                Cancha = t.Cancha != null ? new CanchaDTO
                {
                    Nro = t.Cancha.Nro,
                    TipoCancha = t.Cancha.TipoCancha != null ? new TipoCanchaDTO
                    {
                        Id = t.Cancha.TipoCancha.Id,
                        Deporte = t.Cancha.TipoCancha.Deporte
                    } : null
                } : null,
            }).ToList();
        }
    }
}
