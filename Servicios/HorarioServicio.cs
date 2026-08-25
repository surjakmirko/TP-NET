using Modelo.Dominio;
using Data;
using DTOs;


namespace Servicios
{
    public class HorarioServicio: IHorarioServicio
    {
        private readonly IHorarioRepositorio horarioRepositorio;

        public HorarioServicio(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
        }
        public async Task<HorarioDTO> AddAsync(HorarioDTO dto)
        {

            Horario horario = new Horario(dto.ComplejoId, dto.NroDia, dto.HoraApertura, dto.HoraCierre);

            await horarioRepositorio.AddAsync(horario);

            return dto;
        }

        public async Task<bool> DeleteAsync(int id,int dia)
        {
            return await horarioRepositorio.DeleteAsync(id,dia);
        }

        public async Task<HorarioDTO?> GetAsync(int id, int dia)
        {
            Horario? horario = await horarioRepositorio.GetAsync(id,dia);

            if (horario == null)
                return null;

            return new HorarioDTO
            {
                ComplejoId = horario.ComplejoId,
                NroDia= horario.NroDia,
                HoraApertura = horario.HoraApertura,
                HoraCierre = horario.HoraCierre
            };
        }

        public async Task<IEnumerable<HorarioDTO>> GetAllAsync(int id)
        {
            var horarios = await horarioRepositorio.GetAllAsync(id);

            return horarios.Select(horario => new HorarioDTO
            {
                ComplejoId = horario.ComplejoId,
                NroDia = horario.NroDia,
                HoraApertura = horario.HoraApertura,
                HoraCierre = horario.HoraCierre
            }).ToList();
        }

        public async Task<bool> UpdateAsync(HorarioDTO dto)
        {

            Horario horario = new Horario(dto.ComplejoId, dto.NroDia, dto.HoraApertura, dto.HoraCierre);

            return await horarioRepositorio.UpdateAsync(horario);
        }
    }
}
