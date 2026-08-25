using DTOs;
using Modelo.Dominio;
using Data;

namespace Servicios
{
    public class ProvinciaServicio: IProvinciaServicio
    {
        private readonly IProvinciaRepositorio provinciaRepositorio;
        public ProvinciaServicio(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;
        }
        public async Task<ProvinciaDTO?> GetAsync(int id)
        {
            Provincia? provincia = await provinciaRepositorio.GetAsync(id);

            if (provincia == null)
                return null;

            return new ProvinciaDTO
            {
                Id = provincia.Id,
                Nombre = provincia.Nombre
            };
        }

        public async Task<IEnumerable<ProvinciaDTO>> GetAllAsync()
        {
            var provincias = await provinciaRepositorio.GetAllAsync();

            return provincias.Select(provincia => new ProvinciaDTO
            {
                Id = provincia.Id,
                Nombre = provincia.Nombre
            }).ToList();
        }

    }
}
