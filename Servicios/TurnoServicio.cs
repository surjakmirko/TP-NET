
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
            if (!dto.ClienteId.HasValue)
                throw new ArgumentException("ClienteId es requerido para turnos de cliente.");

            Turno turno = new Turno(dto.HoraInicio, dto.HoraFin, dto.ClienteId.Value, dto.TipoTurnoId, dto.ComplejoId, dto.CanchaNro, dto.Fecha);

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
            if (!dto.ClienteId.HasValue && !string.IsNullOrWhiteSpace(dto.NombreClienteExterno))
            {
                // Cliente externo - usar constructor sin ClienteId
                Turno turno = new Turno(dto.Id, dto.HoraInicio, dto.HoraFin, dto.NombreClienteExterno!, dto.ApellidoClienteExterno!, dto.TipoTurnoId, dto.ComplejoId, dto.CanchaNro, dto.Fecha);
                return await turnoRepositorio.UpdateAsync(turno);
            }
            else if (dto.ClienteId.HasValue)
            {
                // Cliente registrado
                Turno turno = new Turno(dto.Id, dto.HoraInicio, dto.HoraFin, dto.ClienteId.Value, dto.TipoTurnoId, dto.ComplejoId, dto.CanchaNro, dto.Fecha);
                return await turnoRepositorio.UpdateAsync(turno);
            }
            else
            {
                throw new ArgumentException("ClienteId es requerido para turnos de cliente registrado.");
            }
        }
        public async Task<bool> CancelarAsync(int id, string? motivoCancelacion)
        {
            return await turnoRepositorio.CancelarAsync(id, motivoCancelacion);
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
                MotivoCancelacion = t.MotivoCancelacion,
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
                // Cliente externo
                NombreClienteExterno = t.NombreClienteExterno,
                ApellidoClienteExterno = t.ApellidoClienteExterno
            }).ToList();
        }

        public async Task<TurnoDTO> AddEncargadoAsync(TurnoCrearEncargadoDTO dto)
        {
            // Validar que no haya conflicto de horario en la misma cancha
            var turnosExistentes = await turnoRepositorio.GetAllAsync();
            bool conflicto = turnosExistentes.Any(t => 
                t.ComplejoId == dto.ComplejoId && 
                t.CanchaNro == dto.CanchaNro && 
                t.Fecha == dto.Fecha &&
                t.Estado == "Reservado" &&
                t.HoraInicio < dto.HoraFin &&
                t.HoraFin > dto.HoraInicio);

            if (conflicto)
            {
                throw new InvalidOperationException("La cancha ya está reservada en ese horario.");
            }

            var turno = new Turno(dto.HoraInicio, dto.HoraFin, dto.NombreCliente, dto.ApellidoCliente, dto.TipoTurnoId, dto.ComplejoId, dto.CanchaNro, dto.Fecha);

            await turnoRepositorio.AddEncargadoAsync(turno);

            return new TurnoDTO
            {
                Id = turno.Id,
                HoraInicio = turno.HoraInicio,
                HoraFin = turno.HoraFin,
                Estado = turno.Estado,
                MotivoCancelacion = turno.MotivoCancelacion,
                TipoTurnoId = turno.TipoTurnoId,
                ComplejoId = turno.ComplejoId,
                CanchaNro = turno.CanchaNro,
                Fecha = turno.Fecha,
                NombreClienteExterno = turno.NombreClienteExterno,
                ApellidoClienteExterno = turno.ApellidoClienteExterno
            };
        }
    }
}
