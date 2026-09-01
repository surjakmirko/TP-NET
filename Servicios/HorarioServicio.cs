using Modelo.Dominio;
using Data;
using DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Servicios
{
    public class HorarioServicio: IHorarioServicio
    {
        private readonly IHorarioRepositorio horarioRepositorio;

        public HorarioServicio(IHorarioRepositorio horarioRepositorio)
        {
            this.horarioRepositorio = horarioRepositorio;
        }
        public async Task<HorarioDTO> AddAsync(HorarioCrearDTO dto, int idComplejo)
        {

            Horario horario = new Horario(idComplejo, dto.NroDia, dto.HoraApertura, dto.HoraCierre);

            await horarioRepositorio.AddAsync(horario);

            return new HorarioDTO {
                ComplejoId = horario.ComplejoId,
                NroDia = horario.NroDia,
                HoraApertura = horario.HoraApertura,
                HoraCierre = horario.HoraCierre
            }
            ;
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

        public async Task<bool> UpdateAsync(HorarioEditarDTO dto,int complejoId, int numDia)
        {

            Horario horario = new Horario(complejoId, numDia, dto.HoraApertura, dto.HoraCierre);

            return await horarioRepositorio.UpdateAsync(horario);
        }
    }
}
