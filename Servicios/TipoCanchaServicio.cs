using Data;
using DTOs;
using Modelo.Dominio;


namespace Servicios
{
    public class TipoCanchaServicio : ITipoCanchaServicio
    {
        private readonly ITipoCanchaRepositorio tipoCanchaRepositorio;

        public TipoCanchaServicio(ITipoCanchaRepositorio tipoCanchaRepositorio)
        {
            this.tipoCanchaRepositorio = tipoCanchaRepositorio;
        }

        

        

        public async Task<TipoCanchaDTO?> GetAsync(int id)
        {
            TipoCancha? tipoCancha = await tipoCanchaRepositorio.GetAsync(id);

            if (tipoCancha == null)
                return null;

            return new TipoCanchaDTO
            {
                Id = tipoCancha.Id,
                Deporte = tipoCancha.Deporte
            };
        }

        public async Task<IEnumerable<TipoCanchaDTO>> GetAllAsync()
        {
            var tiposCancha = await tipoCanchaRepositorio.GetAllAsync();

            return tiposCancha.Select(tipoCancha => new TipoCanchaDTO
            {
                Id = tipoCancha.Id,
                Deporte = tipoCancha.Deporte
            }).ToList();
        }


        
    }
}
