using Data;
using ModeloDominio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PersonaFisicaServicio : IPersonaFisicaServicio
    {
            private readonly IPersonaFisicaRepositorio personaFisicaRepositorio;

            public PersonaFisicaServicio(IPersonaFisicaRepositorio personaFisicaRepositorio)
            {
                this.personaFisicaRepositorio = personaFisicaRepositorio;
            }

            public async Task<PersonaFisicaDTO> AddAsync(PersonaFisicaDTO dto)
            {
                PersonaFisica personaFisica = new PersonaFisica(dto.Dni, dto.Nombre, dto.Apellido, dto.Fecha_Nacimiento);

                await personaFisicaRepositorio.AddAsync(personaFisica);

                dto.Dni = personaFisica.Dni;

                return dto;
            }

            public async Task<bool> DeleteAsync(int dni)
            {
                return await personaFisicaRepositorio.DeleteAsync(dni);
            }

            public async Task<PersonaFisicaDTO?> GetAsync(int dni)
            {
                PersonaFisica? personaFisica = await personaFisicaRepositorio.GetAsync(dni);

                if (personaFisica == null)
                    return null;

                return new PersonaFisicaDTO
                {
                    Dni = personaFisica.Dni,
                    Nombre = personaFisica.Nombre,
                    Apellido = personaFisica.Apellido,
                    Fecha_Nacimiento = personaFisica.Fecha_Nacimiento
                };
            }

            public async Task<IEnumerable<PersonaFisicaDTO>> GetAllAsync()
            {
                var personas = await personaFisicaRepositorio.GetAllAsync();

                return personas.Select(persona => new PersonaFisicaDTO
                {
                    Dni = persona.Dni,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Fecha_Nacimiento = persona.Fecha_Nacimiento
                }).ToList();
            }

            public async Task<bool> UpdateAsync(PersonaFisicaDTO dto)
            {
                if (await personaFisicaRepositorio.DniExistsAsync(dto.Dni))
                {
                    throw new ArgumentException($"Ya existe otro usuario con el Dni '{dto.Dni}'.");
                }


                PersonaFisica personaFisica = new PersonaFisica(dto.Dni, dto.Nombre, dto.Apellido, dto.Fecha_Nacimiento);

                return await personaFisicaRepositorio.UpdateAsync(personaFisica);
            }
        }
}
