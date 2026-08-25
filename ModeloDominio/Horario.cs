namespace Modelo.Dominio
{
    public class Horario
    {
        public int ComplejoId { get; private set; }
        public Complejo Complejo { get; set; } = null!;

        public int NroDia { get; private set; }
        public TimeOnly HoraApertura { get; private set; }
        public TimeOnly HoraCierre { get; private set; }

        public Horario(int complejoId,int nroDia, TimeOnly horaApertura, TimeOnly horaCierre)
        {
            SetComplejoId(complejoId);
            SetNroDia(nroDia);
            SetHoraApertura(horaApertura);
            SetHoraCierre(horaCierre);
        }

        public void SetComplejoId(int complejoId)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El Id del complejo debe ser mayor que 0.", nameof(complejoId));
            ComplejoId = complejoId;
        }



        public void SetNroDia(int nroDia)
        {
            if (nroDia <= 0 || nroDia >= 9)
                throw new ArgumentException("El número de día debe estar entre 1 y 8.", nameof(nroDia));
            NroDia = nroDia;
        }

        public void SetHoraApertura(TimeOnly horaApertura)
        {
            if (horaApertura < TimeOnly.MinValue || horaApertura > TimeOnly.MaxValue)
                throw new ArgumentException("La hora de apertura debe estar entre 00:00 y 23:59.", nameof(horaApertura));
            HoraApertura = horaApertura;
        }

        public void SetHoraCierre(TimeOnly horaCierre)
        {
            if (horaCierre < TimeOnly.MinValue || horaCierre > TimeOnly.MaxValue)
                throw new ArgumentException("La hora de cierre debe estar entre 00:00 y 23:59.", nameof(horaCierre));
            HoraCierre = horaCierre;
        }
    }
}
