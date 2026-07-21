using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    internal class Turno
    {
        public int Id { get; private set; }
        public TimeOnly HoraInicio { get; private set; }
        public TimeOnly HoraFin { get; private set; }
        public string Estado { get; private set; }
        public string MotivoCancelacion { get; private set; }
        public Turno(int id, TimeOnly horaInicio, TimeOnly horaFin)
        {
            SetId(id);
            SetHoraInicio(horaInicio);
            SetHoraFin(horaFin);
            SetEstado("Reservado");
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetHoraInicio(TimeOnly horaInicio)
        {
            HoraInicio = horaInicio;
        }
        public void SetHoraFin(TimeOnly horaFin)
        {
            HoraFin = horaFin;
        }
        public void SetEstado(string estado)
        {
            Estado = estado;
        }
        public void SetMotivoCancelacion(string motivoCancelacion)
        {
            if (string.IsNullOrWhiteSpace(motivoCancelacion))
                throw new ArgumentException("El motivo de cancelación no puede ser nulo o vacío.", nameof(motivoCancelacion));
            MotivoCancelacion = motivoCancelacion;
        }
    }
}