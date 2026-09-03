
using Modelo.Dominio;
using Data;
using DTOs;

namespace Servicios
{
    public class CanchaServicio: ICanchaServicio
    {
        private readonly ICanchaRepositorio canchaRepositorio;

        public CanchaServicio(ICanchaRepositorio canchaRepositorio)
        {
            this.canchaRepositorio = canchaRepositorio;
        }
        public async Task<CanchaDTO> AddAsync(CanchaCrearDTO dto, int complejoId)
        {

            Cancha cancha = new Cancha(dto.Nro, dto.TipoCanchaId, complejoId);

            await canchaRepositorio.AddAsync(cancha);

            return new CanchaDTO
            {
                ComplejoId = complejoId,
                Nro = dto.Nro,
                TipoCanchaId = dto.TipoCanchaId
            };
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

        public async Task<bool> UpdateAsync(CanchaCrearDTO dto, int complejoId, int nroOriginal)
        {
            Cancha canchaNueva = new Cancha(dto.Nro, dto.TipoCanchaId, complejoId);
            return await canchaRepositorio.UpdateAsync(canchaNueva, nroOriginal);
        }
    }
}
