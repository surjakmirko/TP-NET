using DTOs;
using Modelo.Dominio;
using Data;



namespace Servicios
{
    public class LocalidadServicio: ILocalidadServicio
    {
        private readonly ILocalidadRepositorio localidadRepositorio;
        public LocalidadServicio(ILocalidadRepositorio localidadRepositorio)
        {
            this.localidadRepositorio = localidadRepositorio;
        }
        public async Task<LocalidadDTO?> GetAsync(int id)
        {
            Localidad? localidad = await localidadRepositorio.GetAsync(id);

            if (localidad == null)
                return null;

            return new LocalidadDTO
            {
                Id = localidad.Id,
                Nombre = localidad.Nombre,
                CodigoPostal = localidad.CodigoPostal,
                ProvinciaId = localidad.ProvinciaId
            };
        }

        public async Task<IEnumerable<LocalidadDTO>> GetAllAsync()
        {
            var localidades = await localidadRepositorio.GetAllAsync();

            return localidades.Select(localidad => new LocalidadDTO
            {
                Id = localidad.Id,
                Nombre = localidad.Nombre,
                CodigoPostal = localidad.CodigoPostal,
                ProvinciaId = localidad.ProvinciaId
            }).ToList();
        }

    }
}
