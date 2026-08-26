using Data;
using DTOs;
using Modelo.Dominio;


namespace Servicios
{
    public class PersonaJuridicaServicio : IPersonaJuridicaServicio
    {
        private readonly IPersonaJuridicaRepositorio personaJuridicaRepositorio;
        public PersonaJuridicaServicio(IPersonaJuridicaRepositorio personaJuridicaRepositorio)
        {
            this.personaJuridicaRepositorio = personaJuridicaRepositorio;
        }
        public async Task<PersonaJuridicaDTO> AddAsync(PersonaJuridicaDTO dto)
        {
            PersonaJuridica personaJuridica = new PersonaJuridica(dto.Cuit, dto.Razon_Social);

            await personaJuridicaRepositorio.AddAsync(personaJuridica);

            dto.Cuit = personaJuridica.Cuit;

            return dto;
        }
        public async Task<bool> DeleteAsync(string cuit)
        {
            return await personaJuridicaRepositorio.DeleteAsync(cuit);
        }
        public async Task<PersonaJuridicaDTO?> GetAsync(string cuit)
        {
            PersonaJuridica? personaJuridica = await personaJuridicaRepositorio.GetAsync(cuit);

            if (personaJuridica == null)
                return null;

            return new PersonaJuridicaDTO
            {
                Cuit = personaJuridica.Cuit,
                Razon_Social = personaJuridica.RazonSocial
            };
        }
        public async Task<IEnumerable<PersonaJuridicaDTO>> GetAllAsync()
        {
            var personasJuridicas = await personaJuridicaRepositorio.GetAllAsync();

            return personasJuridicas.Select(personaJuridica => new PersonaJuridicaDTO
            {
                Cuit = personaJuridica.Cuit,
                Razon_Social = personaJuridica.RazonSocial
            }).ToList();
        }
        public async Task<bool> UpdateAsync(PersonaJuridicaDTO dto)
        {
            if (await personaJuridicaRepositorio.CuitExistsAsync(dto.Cuit))
            {
                throw new ArgumentException($"Ya existe otra persona jurídica con el CUIT '{dto.Cuit}'.");
            }


            PersonaJuridica personaJuridica = new PersonaJuridica(dto.Razon_Social, dto.Cuit);
            return await personaJuridicaRepositorio.UpdateAsync(personaJuridica);
        }
    }
}
