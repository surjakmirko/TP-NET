using Modelo.Dominio;
using Data;
using DTOs;

namespace Servicios
{
    public class ComplejoServicio: IComplejoServicio
    {
        private readonly IComplejoRepositorio complejoRepositorio;

        public ComplejoServicio(IComplejoRepositorio complejoRepositorio)
        {
            this.complejoRepositorio = complejoRepositorio;
        }
        public async Task<ComplejoDTO> AddAsync(ComplejoDTO dto)
        {
            
            Complejo complejo = new Complejo(dto.Id, dto.Direccion, dto.Nombre, dto.EncargadoId, dto.DueñoId, dto.LocalidadId);

            await complejoRepositorio.AddAsync(complejo);

            dto.Id = complejo.Id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await complejoRepositorio.DeleteAsync(id);
        }

        public async Task<ComplejoDTO?> GetAsync(int id)
        {
            Complejo? complejo = await complejoRepositorio.GetAsync(id);

            if (complejo == null)
                return null;

            return new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId,
                EncargadoId = complejo.EncargadoId
            };
        }

        public async Task<IEnumerable<ComplejoDTO>> GetAllAsync()
        {
            var complejos = await complejoRepositorio.GetAllAsync();

            return complejos.Select(complejo => new ComplejoDTO
            {
                Id = complejo.Id,
                Direccion = complejo.Direccion,
                Nombre = complejo.Nombre,
                LocalidadId = complejo.LocalidadId,
                DueñoId = complejo.DueñoId,
                EncargadoId = complejo.EncargadoId
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ComplejoDTO dto)
        {

            Complejo complejo = new Complejo(dto.Id, dto.Direccion, dto.Nombre, dto.EncargadoId, dto.DueñoId, dto.LocalidadId);

            return await complejoRepositorio.UpdateAsync(complejo);
        }
    }
}
