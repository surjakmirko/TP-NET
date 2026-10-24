using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Blazor.WebAssembly.Servicios;

namespace Blazor.WebAssembly.Servicios
{
    public class PersonaFisicaApiClient : BlazorApiClient
    {
        public PersonaFisicaApiClient(HttpClient http) : base(http) { }

        public async Task<List<PersonaFisicaDTO>?> GetAllAsync()
        {
            return await GetAsync<List<PersonaFisicaDTO>>("personas-fisicas");
        }

        public async Task<PersonaFisicaDTO?> GetByIdAsync(string dni)
        {
            return await GetAsync<PersonaFisicaDTO>($"personas-fisicas/{dni}");
        }

        public async Task CrearAsync(PersonaFisicaDTO dto)
        {
            await PostAsync("personas-fisicas", dto);
        }

        public async Task ActualizarAsync(PersonaFisicaDTO dto)
        {
            await PutAsync("personas-fisicas", dto);
        }

        public async Task EliminarAsync(string dni)
        {
            await DeleteAsync($"personas-fisicas/{dni}");
        }
    }
}