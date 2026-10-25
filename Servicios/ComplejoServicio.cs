using Modelo.Dominio;
using Data;
using DTOs;

namespace Servicios
{
    public class ComplejoServicio: IComplejoServicio
    {
        private readonly IComplejoRepositorio complejoRepositorio;

        public ComplejoServicio(IComplejoRepositorio complejoRepositorio)
        {
            this.complejoRepositorio = complejoRepositorio;
        }
        public async Task<ComplejoDTO> AddAsync(ComplejoCrearDTO dto)
        {
            // Validar que el encargado no tenga ya un complejo asignado (globalmente)
            var encargadoYaTieneComplejo = await complejoRepositorio.EncargadoTieneComplejoAsync(dto.EncargadoId);
            
            if (encargadoYaTieneComplejo)
            {
                throw new InvalidOperationException("El encargado seleccionado ya tiene un complejo asignado. Un encargado solo puede tener un complejo asignado.");
            }
            
            Complejo complejo = new Complejo(0, dto.Direccion, dto.Nombre, dto.DueñoId, dto.EncargadoId, dto.LocalidadId);

            await complejoRepositorio.AddAsync(complejo);

            return new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                EncargadoId = complejo.EncargadoId,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await complejoRepositorio.DeleteAsync(id);
        }

        public async Task<ComplejoDTO?> GetAsync(int id)
        {
            Complejo? complejo = await complejoRepositorio.GetAsync(id);

            if (complejo == null)
                return null;

            return new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId,
                EncargadoId = complejo.EncargadoId,
                NombreLocalidad = complejo.Localidad.Nombre,
                NombreDueño = complejo.Dueño?.PersonaJuridica?.RazonSocial ?? "Sin Razón Social",
                NombreEncargado = complejo.Encargado?.Email ?? string.Empty,
                ImagenUrl = complejo.ImagenUrl,
                Canchas = complejo.Canchas?.Select(ca => new CanchaDTO
                {
                    Nro = ca.Nro,
                    ComplejoId = ca.ComplejoId,
                    TipoCanchaId = ca.TipoCanchaId,
                    Deporte = ca.TipoCancha?.Deporte ?? string.Empty,
                    Estado = ca.Estado,

                    // Asignamos únicamente el ÚLTIMO Precio a la propiedad individual PrecioDTO
                    PrecioDTO = ca.Precios?
                .OrderByDescending(p => p.FechaDesde) // O p.FechaDesde / p.Id según tu modelo de la BD
                .Select(p => new PrecioDTO
                {
                    FechaDesde = p.FechaDesde,
                    PrecioBase = p.PrecioBase,
                    PrecioAdicional = p.PrecioAdicional,
                    PrecioSena = p.PrecioSena
                })
                .FirstOrDefault(),

                    TipoCancha = ca.TipoCancha != null ? new TipoCanchaDTO
                    {
                        Id = ca.TipoCancha.Id,
                        Deporte = ca.TipoCancha.Deporte
                    } : null,
                    Turnos = ca.Turnos?.Select(t => new TurnoDTO
                    {
                        Id = t.Id,
                        Fecha = t.Fecha,
                        HoraInicio = t.HoraInicio,
                        HoraFin = t.HoraFin,
                        Estado = t.Estado,
                        ClienteId = t.ClienteId
                    }).ToList() ?? new List<TurnoDTO>()
                }).ToList() ?? new List<CanchaDTO>(),

                // Mapeo de Horarios
                Horarios = complejo.Horarios?.Select(h => new HorarioDTO
                {
                    ComplejoId = h.ComplejoId,
                    NroDia = h.NroDia,
                    HoraApertura = h.HoraApertura,
                    HoraCierre = h.HoraCierre
                }).ToList() ?? new List<HorarioDTO>()
            };
        }

        public async Task<IEnumerable<ComplejoTarjetaDTO>> GetByDuenoAsync(int idDueno)
        {
            var complejos = await complejoRepositorio.GetComplejosByIdDueno(idDueno);
            return complejos.Select(c => new ComplejoTarjetaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion,
                NombreLocalidad = c.Localidad?.Nombre ?? string.Empty,
                CantidadCanchas = c.Canchas.Count,
                Deportes = c.Canchas
            .Where(ca => ca.TipoCancha != null)
            .Select(ca => ca.TipoCancha.Deporte)
            .Distinct()
            .ToList(),
                ImagenUrl = c.ImagenUrl
            }).ToList();
        }

        public async Task<ComplejoDTO?> GetByEncargadoAsync(int idEncargado)
        {
            Complejo? complejo = await complejoRepositorio.GetComplejosByIdEncargado(idEncargado);
            if (complejo == null)
            {
                return null;
            }
            return new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId,
                EncargadoId = complejo.EncargadoId,
                NombreLocalidad = complejo.Localidad?.Nombre ?? string.Empty,
                ImagenUrl = complejo.ImagenUrl
            };
        }
        public async Task<List<LocalidadRankingDTO>> GetRankingLocalidadesAsync()
        {
            var datos = await complejoRepositorio.GetRankingLocalidadesAsync();
            return datos.Select((item, index) => new LocalidadRankingDTO
            {
                Posicion = index + 1,
                NombreLocalidad = item.Localidad,
                CantidadComplejos = item.Cantidad
            }).ToList();
        }
        public async Task<IEnumerable<ComplejoDTO>> GetAllAsync()
        {
            var complejos = await complejoRepositorio.GetAllAsync();

            return complejos.Select(complejo => new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId,
                EncargadoId = complejo.EncargadoId,
                NombreLocalidad = complejo.Localidad?.Nombre ?? string.Empty,
                NombreDueño = complejo.Dueño?.PersonaJuridica?.RazonSocial ?? "Sin Razón Social",
                NombreEncargado = complejo.Encargado?.Email ?? string.Empty,
                ImagenUrl = complejo.ImagenUrl,
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ComplejoDTO dto)
        {   
        
            Complejo complejo = new Complejo(dto.Id, dto.Direccion, dto.Nombre, dto.DueñoId, dto.EncargadoId, dto.LocalidadId);

            complejo.SetImagenUrl(dto.ImagenUrl); // (Si en tu modelo de Dominio usas un método Set, pon: complejo.SetImagenUrl(dto.ImagenUrl);)

            return await complejoRepositorio.UpdateAsync(complejo);
        }

        public async Task<IEnumerable<ComplejoDTO>> BuscarAsync(string? ciudad, string? deporte, string? fecha, string? hora, decimal? min, decimal? max)
        {
            var complejos = await complejoRepositorio.BuscarAsync(ciudad, deporte, fecha, hora, min, max);

            return complejos.Select(complejo => new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId,
                EncargadoId = complejo.EncargadoId,
                NombreLocalidad = complejo.Localidad?.Nombre ?? string.Empty,
                NombreDueño = complejo.Dueño?.PersonaJuridica?.RazonSocial ?? "Sin Razón Social",
                NombreEncargado = complejo.Encargado?.Email ?? string.Empty,
                ImagenUrl = complejo.ImagenUrl,
                PrecioDesde = complejo.Canchas
                    .SelectMany(c => c.Precios)
                    .Where(p => p.PrecioBase > 0)
                    .DefaultIfEmpty()
                    .Min(p => p?.PrecioBase ?? 0)
            }).ToList();
        }
    }
}
