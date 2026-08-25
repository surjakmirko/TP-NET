
using Modelo.Dominio;
using Data;
using DTOs;

namespace Servicios
{
    public class CanchaServicio: ICanchaServicio
    {
        private readonly ICanchaRepositio canchaRepositorio;

        public CanchaServicio(IHorarioRepositorio horarioRepositorio)
        {
            this.canchaRepositorio = canchaRepositorio;
        }
        public async Task<CanchaDTO> AddAsync(CanchaDTO dto)
        {

            Cancha cancha = new Cancha(dto.ComplejoId, dto.Nro, dto.TipoCanchaId);

            await canchaRepositorio.AddAsync(cancha);

            return dto;
        }

        public async Task<bool> DeleteAsync(int id, int nro)
        {
            return await canchaRepositorio.DeleteAsync(id, nro);
        }

        public async Task<CanchaDTO?> GetAsync(int id, int nro)
        {
            Cancha? cancha = await canchaRepositorio.GetAsync(id, nro);

            if (cancha == null)
                return null;

            return new CanchaDTO
            {
                ComplejoId = cancha.ComplejoId,
                Nro= cancha.Nro,
                TipoCanchaId = cancha.TipoCanchaId
            };
        }

        public async Task<IEnumerable<CanchaDTO>> GetAllAsync(int id)
        {
            var canchas = await canchaRepositorio.GetAllAsync(id);

            return canchas.Select(cancha => new CanchaDTO
            {
                ComplejoId = cancha.ComplejoId,
                Nro = cancha.Nro,
                TipoCanchaId = cancha.TipoCanchaId
            }).ToList();
        }

        public async Task<bool> UpdateAsync(CanchaDTO dto)
        {

            Cancha cancha = new Cancha(dto.ComplejoId, dto.Nro, dto.TipoCanchaId);

            return await canchaRepositorio.UpdateAsync(cancha);
        }
    }
}
