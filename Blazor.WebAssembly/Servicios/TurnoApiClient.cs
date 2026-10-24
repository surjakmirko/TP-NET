using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Blazor.WebAssembly.Servicios;

namespace Blazor.WebAssembly.Servicios
{
    public class TurnoApiClient : BlazorApiClient
    {
        public TurnoApiClient(HttpClient http) : base(http) { }

        public async Task<List<TurnoDTO>?> GetAllAsync()
        {
            return await GetAsync<List<TurnoDTO>>("turnos");
        }

        public async Task<TurnoDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<TurnoDTO>($"turnos/{id}");
        }

        public async Task<TurnoDTO?> CrearAsync(TurnoCrearDTO dto)
        {
            return await PostAsync<TurnoCrearDTO, TurnoDTO>("turnos", dto);
        }

        public async Task ActualizarAsync(TurnoDTO dto)
        {
            await PutAsync("turnos", dto);
        }

        public async Task EliminarAsync(int id)
        {
            await DeleteAsync($"turnos/{id}");
        }
    }
}