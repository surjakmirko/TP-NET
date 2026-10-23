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
                    } : null
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
            .ToList()
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
                NombreLocalidad = complejo.Localidad?.Nombre ?? string.Empty
            };
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
                NombreEncargado = complejo.Encargado?.Email ?? string.Empty
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ComplejoDTO dto)
        {   
        
            Complejo complejo = new Complejo(dto.Id, dto.Direccion, dto.Nombre, dto.DueñoId, dto.EncargadoId, dto.LocalidadId);

            return await complejoRepositorio.UpdateAsync(complejo);
        }

        public async Task<IEnumerable<ComplejoDTO>> BuscarAsync(string? ciudad, string? deporte, string? fecha, string? hora, decimal? min, decimal? max)
        {
            // Llamas al repositorio pasándole todos los parámetros de búsqueda
            var complejos = await complejoRepositorio.BuscarAsync(ciudad, deporte, fecha, hora, min, max);

            // Mapeas las entidades resultantes a ComplejoDTO
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
                NombreEncargado = complejo.Encargado?.Email ?? string.Empty
            }).ToList();
        }
    }
}
