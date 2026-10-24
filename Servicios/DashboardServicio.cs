using Data;
using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IDashboardRepositorio _dashboardRepositorio;

        public DashboardServicio(IDashboardRepositorio dashboardRepositorio)
        {
            _dashboardRepositorio = dashboardRepositorio;
        }

        public async Task<DashboardDuenoDTO> ObtenerMetricasDuenoAsync(int idDueno, DateOnly fecha)
        {
            var complejos = (await _dashboardRepositorio.ObtenerDatosDashboardDueno(idDueno, fecha)).ToList();

            var canchas = complejos
                .SelectMany(c => c.Canchas)
                .ToList();

            var turnos = canchas
                .SelectMany(ca => ca.Turnos.Select(t => new { Cancha = ca, Turno = t }))
                .Where(x => !EstaCancelado(x.Turno))
                .ToList();

            var canchasActivas = canchas
                .Where(EstaActiva)
                .ToList();

            var turnosEnCanchasActivas = turnos
                .Where(x => EstaActiva(x.Cancha))
                .ToList();

            var horasReservadas = turnosEnCanchasActivas
                .Sum(x => ObtenerDuracionHoras(x.Turno));

            var horasDisponibles = CalcularHorasDisponibles(complejos, canchasActivas, fecha);

            var ocupacion = horasDisponibles > 0
                ? Math.Min(100, horasReservadas / horasDisponibles * 100)
                : 0;

            var deporteEstrella = turnos
                .GroupBy(x => string.IsNullOrWhiteSpace(x.Cancha.TipoCancha?.Deporte)
                    ? "Sin deporte"
                    : x.Cancha.TipoCancha.Deporte)
                .Select(g => new
                {
                    Nombre = g.Key,
                    Reservas = g.Count()
                })
                .OrderByDescending(x => x.Reservas)
                .ThenBy(x => x.Nombre)
                .FirstOrDefault();

            return new DashboardDuenoDTO
            {
                IngresosEstimados = turnos.Sum(x => ObtenerPrecioVigente(x.Cancha, fecha)),
                CantidadTurnos = turnos.Count,
                CantidadCanchas = canchasActivas.Count,
                OcupacionPorcentaje = Math.Round(ocupacion, 1, MidpointRounding.AwayFromZero),
                DeporteEstrellaNombre = deporteEstrella?.Nombre,
                DeporteEstrellaReservas = deporteEstrella?.Reservas ?? 0
            };
        }

        private static decimal ObtenerPrecioVigente(Cancha cancha, DateOnly fecha)
        {
            return cancha.Precios
                .Where(p => p.FechaDesde <= fecha)
                .OrderByDescending(p => p.FechaDesde)
                .Select(p => p.PrecioBase)
                .FirstOrDefault();
        }

        private static double CalcularHorasDisponibles(
            IEnumerable<Complejo> complejos,
            IEnumerable<Cancha> canchasActivas,
            DateOnly fecha)
        {
            var nroDia = (int)fecha.DayOfWeek;
            if (nroDia == 0)
            {
                nroDia = 7;
            }

            var totalHoras = 0d;

            foreach (var complejo in complejos)
            {
                var horario = complejo.Horarios.FirstOrDefault(h => h.NroDia == nroDia);
                if (horario == null)
                {
                    continue;
                }

                var cantidadCanchasActivas = canchasActivas.Count(c => c.ComplejoId == complejo.Id);
                if (cantidadCanchasActivas == 0)
                {
                    continue;
                }

                var apertura = horario.HoraApertura.ToTimeSpan();
                var cierre = horario.HoraCierre.ToTimeSpan();

                if (cierre <= apertura)
                {
                    cierre = cierre.Add(TimeSpan.FromHours(24));
                }

                totalHoras += (cierre - apertura).TotalHours * cantidadCanchasActivas;
            }

            return totalHoras;
        }

        private static double ObtenerDuracionHoras(Turno turno)
        {
            var inicio = turno.HoraInicio.ToTimeSpan();
            var fin = turno.HoraFin.ToTimeSpan();

            if (fin <= inicio)
            {
                fin = fin.Add(TimeSpan.FromHours(24));
            }

            return (fin - inicio).TotalHours;
        }

        private static bool EstaActiva(Cancha cancha)
        {
            return !string.Equals(cancha.Estado, "Inactiva", StringComparison.OrdinalIgnoreCase);
        }

        private static bool EstaCancelado(Turno turno)
        {
            return string.Equals(turno.Estado, "Cancelado", StringComparison.OrdinalIgnoreCase);
        }
    }
}
